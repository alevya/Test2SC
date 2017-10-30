using System;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class ReportKindViewModel : ViewModelBase
    {
        private bool _isSelected;
        private BaseFilterReportViewModel _filter;
        public ReportKindViewModel(ReportKind reportKind)
        {
            if(reportKind == null) throw new ArgumentException("reportKind");
            //Filter = BaseFilterReportViewModel.BuildViewModel(reportKind.Filter);

            Name = reportKind.Name;
            Description = reportKind.Description;
            IsSelected = reportKind.IsSelected;
        }

        public BaseFilterReportViewModel Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnPropertyChanged();
            }
        }

        #region Properties
        public string Name { get; }
        public string Description { get; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
