using System;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class ReportKindViewModel : ViewModelBase
    {
        private bool _isSelected;
        private FilterReportIntervalViewModel _filter;
        public ReportKindViewModel(ReportKind reportKind)
        {
            if(reportKind == null) throw new ArgumentException("reportKind");
            
            Name = reportKind.Name;
            Description = reportKind.Description;
            IsSelected = reportKind.IsSelected;
        }

        public FilterReportIntervalViewModel Filter
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
