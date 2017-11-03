using System.Collections.ObjectModel;
using System.Data.Entity;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class FilterAddReportViewModel : ViewModelBase, IReportKind
    {
        public FilterAddReportViewModel(ReportKind model)
        {
            Model = model;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTables.SystemTable> SystemTables { get; set; }
        
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

        public string Description
        {
            get => Model.Description;
            set
            {
                Model.Description = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => Model.IsSelected;
            set
            {
                Model.IsSelected = value;
                OnPropertyChanged();
            }
        }
        public void GetContent()
        {
            using (var context = new ReportContext("system"))
            {
                context.SystemTables.Load();

                SystemTables = context.SystemTables.Local;
            }

        }

        #endregion
    }
}
