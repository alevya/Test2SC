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
            _filterIntervalViewModel = baseFilterReportViewModel;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTables.SystemNotificationGroup> SystemNotificationGroups { get; set; }

        public IReportFilter BaseFilterViewModel
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

        public string Name
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
                OnPropertyChanged();
            }
        }

        public void GetContent()
        {
            using (var context = new ReportContext("system"))
            {
                context.SystemTables.Load();
                SystemNotificationGroups = context.SystemNotificationGroups.Local;
            }
        }

        #endregion
    }
}
