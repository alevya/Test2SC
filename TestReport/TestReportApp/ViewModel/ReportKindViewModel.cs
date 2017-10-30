using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class ReportKindViewModel : ViewModelBase
    {
        private BaseFilterReportViewModel _filter;
        public ReportKindViewModel(ReportKind reportKind)
        {
            if(reportKind == null) throw new ArgumentException("reportKind");
            Filter = BaseFilterReportViewModel.BuildViewModel(reportKind.Filter);
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
    }
}
