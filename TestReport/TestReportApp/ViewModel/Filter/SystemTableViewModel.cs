using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel.Filter
{
    internal class SystemTableViewModel : ViewModelBase
    {
        private bool _isSelected;
        #region Init
        public SystemTableViewModel(string name)
        {
            Name = name;
        }
        #endregion

        #region Properties

        public string Name { get; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        #endregion 
    }
}
