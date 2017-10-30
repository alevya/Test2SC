using System;
using TestReportApp.DbProvider.Models.Filter;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class BaseFilterReportViewModel : ViewModelBase
    {
        public static BaseFilterReportViewModel BuildViewModel(FilterReport filterReport)
        {
            if (filterReport == null) throw new ArgumentException("fiterReport");


            if (filterReport is FilterReportAdd)
            {
                return new FilterReportViewModel();
            }
            return new BaseFilterReportViewModel();
        }
    }
}
