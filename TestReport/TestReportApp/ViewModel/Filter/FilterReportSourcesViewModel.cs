using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel.Filter
{
    internal class FilterReportSourcesViewModel : ViewModelBase, IReportFilter
    {
        private BaseSystemTableViewModel _currentSystemTableDetail;
        private ShapeReportViewModel _currentShape;
        public FilterReportSourcesViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            Name = model.Name;
            NameSystemTable = "Выбор источника";
            FilterIntervalViewModel = baseFilterReportViewModel;

            ShapesCodeReport = new ObservableCollection<ShapeReportViewModel>
                               {
                                   new ShapeReportViewModel(ShapeCodeReport.LineChart),
                                   new ShapeReportViewModel(ShapeCodeReport.PieChart),
                               };
            CurrentShape = ShapesCodeReport.FirstOrDefault();
            //SelectSystemTableDetail = new DelegateCommand(
            //     o=> CurrentSystemTableDetail.IsSelected = !CurrentSystemTableDetail.IsSelected,
            //     o=> CurrentSystemTableDetail != null
            //     );
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
        public ObservableCollection<ShapeReportViewModel> ShapesCodeReport { get; set; }
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

        public async void GetDataForReport()
        {
            Debug.WriteLine("Получение данных из базы для отчета по источникам");

            var intervalViewModel = this.FilterIntervalViewModel as FilterReportIntervalViewModel;
            if(intervalViewModel == null) return;
            var dtFrom = intervalViewModel.DateFrom;
            var dtTo = intervalViewModel.DateTo;
            
            var dbNames = intervalViewModel.GetDatabaseNameFromInterval();
            var selectedSysTables = SystemTableDetails.Where(s => s.IsSelected);

            if (!selectedSysTables.Any()) return;

            var dResult = new Dictionary<string, int>();
            foreach (var dbName in dbNames)
            {
                using (var context = new ReportContext(dbName))
                {
                    foreach (var table in selectedSysTables)
                    {
                        var sQuery = $"SELECT COUNT(*) FROM `db0_{table.Name}` WHERE P_S_DateTime >= '{dtFrom}' AND P_S_DateTime <= '{dtTo}'" +
                                     " UNION " +
                                     $"SELECT COUNT(*) FROM `normalized_{table.Name}` WHERE P_S_DateTime >= '{dtFrom}' AND P_S_DateTime <= '{dtTo}'";
                        var res = await context.Database.SqlQuery<int>(sQuery).ToListAsync();
                        dResult.Add(table.Name, res.Sum());
                    }
                    
                }
            }
        }

        #endregion

        #region Command

        public ICommand SelectSystemTableDetail { get; set; }

        #endregion
    }
}
