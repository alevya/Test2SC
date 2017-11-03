using System.Collections.ObjectModel;
using System.Data.Entity;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class FilterReportSourcesViewModel : ViewModelBase, IReportFilter
    {
        private IReportFilter _filterIntervalViewModel;

        public FilterReportSourcesViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            Name = "Выбор источников";
            _filterIntervalViewModel = baseFilterReportViewModel;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTables.SystemTable> ItemsSource { get; set; }

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
                ItemsSource = context.SystemTables.Local;
            }
        }

        #endregion
    }
}
