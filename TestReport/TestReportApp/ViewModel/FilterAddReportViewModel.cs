using System.Collections.ObjectModel;
using System.Data.Entity;
using TestReportApp.DbProvider;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class FilterAddReportViewModel : ViewModelBase, IReportFilter
    {
        private IReportFilter _baseFilterViewModel;
        private readonly TypeCodeReport _typeReport;

        public FilterAddReportViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            _typeReport = model.TypeCode;
            _baseFilterViewModel = baseFilterReportViewModel;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTables.SystemTable> SystemTables { get; set; }

        public IReportFilter BaseFilterViewModel
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
            string dbName;
            switch (_typeReport)
            {
                case TypeCodeReport.ОтчетПоИсточникам:
                    dbName = "system";
                    break;
                case TypeCodeReport.ОтчетПоУведомлениям:
                    dbName = "";
                    break;
                default:
                    dbName = string.Empty;
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
