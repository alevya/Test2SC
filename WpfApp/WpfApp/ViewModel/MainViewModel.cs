using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Annotations;
using WpfApp.View;

namespace WpfApp.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ReportWorkspace = new ReportWorkspaceViewModel();
           

        }

        #region Properties
        public ReportWorkspaceViewModel ReportWorkspace { get; }

        #endregion
    }
}
