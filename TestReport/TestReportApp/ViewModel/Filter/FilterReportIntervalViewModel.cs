using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel.Filter
{
   
    internal class FilterReportIntervalViewModel : ViewModelBase, IReportFilter
    {
        private DateTime _dateTimeFrom;
        private DateTime _dateTimeTo;

        public FilterReportIntervalViewModel(ReportKind model)
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

        #region IReportFilter Implements

        public string Name
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ShapeReportViewModel> ShapesCodeReport { get; }
        public ShapeReportViewModel CurrentShape { get; set; }

        public void GetContent()
        {   }

        public void GetDataForReport()
        {
            Debug.WriteLine("Получение данных из базы для отчета ТОЛЬКО по интервалу");
        }

        #endregion
    }
}
