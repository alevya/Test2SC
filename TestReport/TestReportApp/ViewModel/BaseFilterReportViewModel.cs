using System;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;
using TestReportApp.ViewModel;

namespace TestReportApp.ViewModel
{
   
    internal class BaseFilterReportViewModel : ViewModelBase, IReportFilter
    {
        private DateTime _dateTimeFrom;
        private DateTime _dateTimeTo;

        public BaseFilterReportViewModel(ReportKind model)
        {
            Model = model;

            var dtNow = DateTime.Now;
            _dateTimeFrom = new DateTime(dtNow.Year, dtNow.Month, 1);
            _dateTimeTo = dtNow;
        }

        public ReportKind Model { get; }

        public DateTime DateFrom
        {
            get => _dateTimeFrom;
            set
            {
                _dateTimeFrom = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateTo
        {
            get => _dateTimeTo;
            set
            {
                _dateTimeTo = value;
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
