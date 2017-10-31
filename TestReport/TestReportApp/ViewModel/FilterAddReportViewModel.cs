using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReportApp.DbProvider.Models.Filter;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class FilterAddReportViewModel : ViewModelBase
    {
        public FilterAddReportViewModel(FilterReportAdd model)
        {
            Model = model;
        }
        public FilterReportAdd Model { get; }

        public IEnumerable<string> UsageValues
        {
            get { return this.Model.UsageValues; }
        }
    }
}
