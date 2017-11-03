using System.Collections.ObjectModel;
using System.Data.Entity;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;
using static TestReportApp.ViewModel.TypeReport;

namespace TestReportApp.ViewModel
{
    internal class FilterAddReportViewModel : ViewModelBase, IReportKind
    {
        private IReportKind _baseFilterViewModel;
        private TypeReport _typeReport;
        public FilterAddReportViewModel(ReportKind model, IReportKind baseFilterReportViewModel, TypeReport typeReport)
        {
            Model = model;
            _baseFilterViewModel = baseFilterReportViewModel;
            _typeReport = typeReport;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTables.SystemTable> SystemTables { get; set; }

        public IReportKind BaseFilterViewModel
        {
            get => _baseFilterViewModel;
            set
            {
                _baseFilterViewModel = value;
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
            string dbName = string.Empty;
            switch (_typeReport)
            {
                case ОтчетПоИсточникам:
                    dbName = "system";
                    break;
                case TypeReport.ОтчетПоУведомлениям:
                    dbName = "";
                    break;
                    
            }
            if(string.IsNullOrEmpty(dbName)) return;

            using (var context = new ReportContext(dbName))
            {
                
                context.SystemTables.Load();

                SystemTables = context.SystemTables.Local;
            }

        }

        #endregion
    }
}
