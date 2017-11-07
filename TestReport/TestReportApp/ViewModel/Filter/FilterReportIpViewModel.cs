using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel.Filter
{
    internal class FilterReportIpViewModel : ViewModelBase, IReportFilter
    {
        private BaseSystemTableViewModel _currentSystemTableDetail;
        private ShapeReportViewModel _currentShape;

        public FilterReportIpViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            NameSystemTable = "Выбор источника";
            FilterIntervalViewModel = baseFilterReportViewModel;

            ShapesCodeReport = new ObservableCollection<ShapeReportViewModel>
                               {
                                   new ShapeReportViewModel(ShapeCodeReport.TableChart),
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
            set{}
        }
        public ObservableCollection<ShapeReportViewModel> ShapesCodeReport { get; }

        public ShapeReportViewModel CurrentShape
        {
            get => _currentShape;
            set
            {
                _currentShape = value;
                OnPropertyChanged();
            }
        }

        public void GetContent()
        {
            using (var context = new ReportContext("system"))
            {
                context.SystemTables.Where(t => t.InnerName.StartsWith("db0_")).Load();
                SystemTableDetails = new ObservableCollection<BaseSystemTableViewModel>();
                foreach (var st in context.SystemTables.Local)
                {
                    SystemTableDetails.Add(new SystemTableViewModel(st.Name, st.InnerName));
                }
                //CurrentSystemTableDetail = SystemTableDetails.FirstOrDefault();
            }
        }

        public async void GetDataForReport(ReportWorkspaceViewModel reportWorkspaceViewModel = null)
        {
            Debug.WriteLine("Получение данных из базы для отчета по IP-адресам");

            var intervalViewModel = this.FilterIntervalViewModel as FilterReportIntervalViewModel;
            if (intervalViewModel == null) return;
            var dtFrom = intervalViewModel.DateFrom;
            var dtTo = intervalViewModel.DateTo;

            var dbNames = intervalViewModel.GetDatabaseNameFromInterval();
            var selectedSysTables = SystemTableDetails.Cast<SystemTableViewModel>().Where(s => s.IsSelected).ToList();

            if (!selectedSysTables.Any()) return;

            var dResult = new Dictionary<string, int>();
            foreach (var dbName in dbNames)
            {
                try
                {
                    using (var context = new ReportContext(dbName))
                    {
                        foreach (var table in selectedSysTables)
                        {
                            var sQuery =
                                $"SELECT P_S_IPv4, Count(*) AS Amount FROM `{table.InnerName}` WHERE P_S_DateTime >= '{dtFrom}' AND P_S_DateTime <= '{dtTo}' GROUP BY P_S_IPv4 " +
                                " UNION " +
                                $"SELECT P_S_IPv4, Count(*) AS Amount FROM `normalized_{table.Name}` WHERE P_S_DateTime >= '{dtFrom}' AND P_S_DateTime <= '{dtTo}' GROUP BY P_S_IPv4 ";

                            var res = await context.Database.SqlQuery<IpInfo>(sQuery).ToListAsync();
                            foreach (var item in res)
                            {
                                if (!dResult.ContainsKey(item.P_S_IPv4))
                                    dResult.Add(item.P_S_IPv4, item.Amount);
                                else
                                    dResult[item.P_S_IPv4] += item.Amount;
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    Debug.WriteLine(exc.Message);
                }
            }
        }

        public class IpInfo
        {
            public string P_S_IPv4{ get; set; }
            public int Amount { get; set; }
        }

        #endregion
    }
}
