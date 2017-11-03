using System.Collections.ObjectModel;
using System.Data.Entity;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class FilterReportNotifyViewModel : ViewModelBase, IReportFilter
    {
        private IReportFilter _filterIntervalViewModel;

        public FilterReportNotifyViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            Name = "Выбор уведомлений";
            _filterIntervalViewModel = baseFilterReportViewModel;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTables.SystemNotificationGroup> ItemsSource { get; set; }

        public IReportFilter FilterIntervalViewModel
        {
            get => _filterIntervalViewModel;
            set
            {
                _filterIntervalViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion
        #region IReportKind Implements

        public string Name { get; set; }

        public void GetContent()
        {
            using (var context = new ReportContext("system"))
            {
                context.SystemTables.Load();
                ItemsSource = context.SystemNotificationGroups.Local;
            }
        }

        #endregion
    }
}
