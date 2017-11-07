using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
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

            //var dtNow = DateTime.Now;
            //_dateTimeFrom = new DateTime(dtNow.Year, dtNow.Month, 1);
            //_dateTimeTo = dtNow;

            var dtNow = DateTime.Now;
            _dateTimeFrom = new DateTime(2017, 10, 1);
            _dateTimeTo = new DateTime(2017, 10, 31);

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

        public IEnumerable<string> GetDatabaseNameFromInterval()
        {
            return new HashSet<string>
                     {
                         string.Format(CultureInfo.InvariantCulture, "z_{0:MMMMM}_{1:yyyy}", this.DateFrom, this.DateFrom),
                         string.Format(CultureInfo.InvariantCulture, "z_{0:MMMMM}_{1:yyyy}", this.DateTo, this.DateTo)
                     };
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

        public void GetDataForReport(ReportWorkspaceViewModel reportWorkspaceViewModel = null)
        {
            Debug.WriteLine("Получение данных из базы для отчета ТОЛЬКО по интервалу");
        }

        #endregion
    }

}
