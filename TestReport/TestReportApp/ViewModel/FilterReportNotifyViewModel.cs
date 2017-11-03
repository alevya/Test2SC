using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class FilterReportNotifyViewModel : ViewModelBase, IReportFilter
    {
        public FilterReportNotifyViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            Name = "Выбор уведомлений";
            FilterIntervalViewModel = baseFilterReportViewModel;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTables.SystemNotificationGroup> ItemsSource { get; set; }

        public IReportFilter FilterIntervalViewModel { get; set; }

        #endregion
        #region IReportKind Implements

        public string Name { get; set; }

        public void GetContent()
        {
            using (var context = new ReportContext("system"))
            {
                context.SystemNotificationGroups.Load();
                ItemsSource = context.SystemNotificationGroups.Local;
            }
        }

        #endregion
    }
}
