using System.Collections.ObjectModel;
using System.Data.Entity;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class FilterReportSourcesViewModel : ViewModelBase, IReportFilter
    {
        public FilterReportSourcesViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            Name = "Выбор источников";
            FilterIntervalViewModel = baseFilterReportViewModel;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTables.SystemTable> ItemsSource { get; set; }

        public IReportFilter FilterIntervalViewModel { get; set; }
        
        #endregion
        #region IReportKind Implements

        public string Name { get; set; }

        public void GetContent()
        {
            using (var context = new ReportContext("system"))
            {
                context.SystemTables.Load();
                ItemsSource = context.SystemTables.Local;
            }
        }

        public void GetDataForReport()
        {
            
        }

        #endregion
    }
}
