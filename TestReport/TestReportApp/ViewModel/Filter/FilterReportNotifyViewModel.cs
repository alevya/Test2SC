using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
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
            Name = "Выбор уведомлений";
            FilterIntervalViewModel = baseFilterReportViewModel;
        }

        #region Properties
        public ReportKind Model { get; }

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
        #region IReportKind Implements

        public string Name { get; set; }

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
            CurrentSystemTableDetail = SystemTableDetails.FirstOrDefault();
        }

        public void GetDataForReport()
        {
            Debug.WriteLine("Получение данных из базы для отчета по уведомлениям");

            var intervalViewModel = this.FilterIntervalViewModel as FilterReportIntervalViewModel;
            var dtFrom = intervalViewModel?.DateFrom;
            var dtTo = intervalViewModel?.DateTo;
        }

        #endregion
    }
}
