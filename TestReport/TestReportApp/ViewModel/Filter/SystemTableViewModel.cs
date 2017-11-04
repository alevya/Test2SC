namespace TestReportApp.ViewModel.Filter
{
    internal class SystemTableViewModel : BaseSystemTableViewModel
    {
        #region Init
        public SystemTableViewModel(string name, string innerName)
        {
            Name = name;
            InnerName = innerName;
        }
        #endregion

        #region Properties

        public string InnerName { get; }
        #endregion 
    }
}
