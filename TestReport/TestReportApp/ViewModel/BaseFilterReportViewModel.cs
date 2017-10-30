using System;
using TestReportApp.DbProvider.Models.Filter;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    public enum FilterViewType
    {
        BaseFilter,
        AddFilter
    };
    internal class BaseFilterReportViewModel : ViewModelBase
    {
        public FilterViewType ViewType { get; set; }

        //public static BaseFilterReportViewModel BuildViewModel(FilterReport filterReport)
        //{
        //    if (filterReport == null) throw new ArgumentException("fiterReport");


        //    if (filterReport is FilterReportAdd)
        //    {
        //        return new FilterReportViewModel();
        //    }
        //    return new BaseFilterReportViewModel();
        //}
    }
}
