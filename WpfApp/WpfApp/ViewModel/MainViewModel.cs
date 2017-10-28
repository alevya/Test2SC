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
