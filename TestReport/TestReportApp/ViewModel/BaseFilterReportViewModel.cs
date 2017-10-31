using System;
using TestReportApp.DbProvider.Models.Filter;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
   
    internal class BaseFilterReportViewModel : ViewModelBase
    {

        public BaseFilterReportViewModel(FilterReport model)
        {
            Model = model;
        }

        public FilterReport Model { get; }

        public DateTime DateFrom
        {
            get => Model.DateFrom;
            set
            {
                Model.DateFrom = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateTo
        {
            get => Model.DateTo;
            set
            {
                Model.DateTo = value;
                OnPropertyChanged();
            }
        }

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
