using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReportApp.DbProvider.Models;
using TestReportApp.DbProvider.Models.Filter;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class FilterAddReportViewModel : ViewModelBase, IReportKind
    {
        public FilterAddReportViewModel(ReportKind model)
        {
            Model = model;
        }
        public ReportKind Model { get; }

        //public IEnumerable<string> UsageValues
        //{
        //    get { return this.Model.UsageValues; }
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
