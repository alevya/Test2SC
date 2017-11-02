using System;
using TestReportApp.DbProvider.Models;
using TestReportApp.DbProvider.Models.Filter;
using TestReportApp.ViewModel.Helpers;
using TestReportApp.ViewModel;

namespace TestReportApp.ViewModel
{
   
    internal class BaseFilterReportViewModel : ViewModelBase, IReportKind
    {

        public BaseFilterReportViewModel(ReportKind model)
        {
            Model = model;
        }

        public ReportKind Model { get; }

        //public DateTime DateFrom
        //{
        //    get => Model.DateFrom;
        //    set
        //    {
        //        Model.DateFrom = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public DateTime DateTo
        //{
        //    get => Model.DateTo;
        //    set
        //    {
        //        Model.DateTo = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public static BaseFilterReportViewModel BuildViewModel(FilterReport filterReport)
        //{
        //    if (filterReport == null) throw new ArgumentException("fiterReport");


        //    if (filterReport is FilterReportAdd)
        //    {
        //        return new FilterReportViewModel();
        //    }
        //    return new BaseFilterReportViewModel();
        //}

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
            
        }

        #endregion
    }
}
