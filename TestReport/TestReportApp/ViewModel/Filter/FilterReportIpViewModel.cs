using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using TestReportApp.DbProvider;
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

        public void GetDataForReport()
        {
            Debug.WriteLine("Получение данных из базы для отчета по IP-адресам");
        }

        #endregion
    }
}
