using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using TestReportApp.DbProvider;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel.Filter
{
    internal class FilterReportNotifyViewModel : ViewModelBase, IReportFilter
    {
        private BaseSystemTableViewModel _currentSystemTableDetail;

        public FilterReportNotifyViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            Name = model.Name;
            NameSystemTable = "Выбор уведомления";
            FilterIntervalViewModel = baseFilterReportViewModel;

            ShapesCodeReport = new ObservableCollection<ShapeReportViewModel>
                               {
                                   new ShapeReportViewModel(ShapeCodeReport.ColumnChart),
                                   new ShapeReportViewModel(ShapeCodeReport.PieChart),
                                   new ShapeReportViewModel(ShapeCodeReport.LineChart),
                               };
            CurrentShape = ShapesCodeReport.FirstOrDefault();
        }

        #region Properties
        public ReportKind Model { get; }
        public string NameSystemTable { get; }

        public ObservableCollection<BaseSystemTableViewModel> SystemTableDetails { get; set; }

        public BaseSystemTableViewModel CurrentSystemTableDetail
        {
            get => _currentSystemTableDetail;
            set
            {
                _currentSystemTableDetail = value;
                OnPropertyChanged();
            }
        }

        public IReportFilter FilterIntervalViewModel { get; set; }

        #endregion
        #region IReportFilter Implements

        public string Name
        {
            get { return Model?.Name; }
            set { }
        }
        public ObservableCollection<ShapeReportViewModel> ShapesCodeReport { get; }
        public ShapeReportViewModel CurrentShape { get; set; }

        public void GetContent()
        {
            using (var context = new ReportContext("system"))
            {
                context.SystemNotificationGroups.Where(t => t.Switch.StartsWith("korrelation_")).Load();
                SystemTableDetails = new ObservableCollection<BaseSystemTableViewModel>();
                foreach (var st in context.SystemNotificationGroups.Local)
                {
                    SystemTableDetails.Add(new SystemNotifyGroupViewModel(st.Name, st.Switch));
                }
            }
        }

        public async void GetDataForReport(ReportWorkspaceViewModel reportWorkspaceViewModel = null)
        {
            Debug.WriteLine("Получение данных из базы для отчета по уведомлениям");

            var intervalViewModel = this.FilterIntervalViewModel as FilterReportIntervalViewModel;
            if (intervalViewModel == null) return;
            var dtFrom = intervalViewModel.DateFrom;
            var dtTo = intervalViewModel.DateTo;

            var dbNames = intervalViewModel.GetDatabaseNameFromInterval();
            var selectedSysTables = SystemTableDetails.Cast<SystemNotifyGroupViewModel>().Where(s => s.IsSelected).ToList();

            if (!selectedSysTables.Any()) return;

            var dResult = new Dictionary<string, List<DateTime>>();
            foreach (var dbName in dbNames)
            {
                try
                {
                    using (var context = new ReportContext(dbName))
                    {
                        foreach (var table in selectedSysTables)
                        {
                            var sQuery =
                                $"SELECT P_S_DateTime FROM `{table.Switch}` WHERE P_S_DateTime >= '{dtFrom}' AND P_S_DateTime <= '{dtTo}'";
                            var res = await context.Database.SqlQuery<DateTime>(sQuery).ToListAsync();

                            if (!dResult.ContainsKey(table.Name))
                                dResult.Add(table.Name, res);
                            //else
                            //    dResult[dbName] += res.Sum();
                        }

                    }
                }
                catch (Exception exc)
                {
                    Debug.WriteLine(exc.Message);
                }
            }

            var currentViewShape = this.GetChartView(CurrentShape.ShapeReport, dResult, dtFrom, dtTo);
            if (reportWorkspaceViewModel != null)
                reportWorkspaceViewModel.ChartView = currentViewShape;

        }

        #endregion
    }
}
