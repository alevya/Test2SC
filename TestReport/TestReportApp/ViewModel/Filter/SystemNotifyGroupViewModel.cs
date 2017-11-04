namespace TestReportApp.ViewModel.Filter
{
    internal class SystemNotifyGroupViewModel : BaseSystemTableViewModel
    {
        #region Init
        public SystemNotifyGroupViewModel(string name, string switch_)
        {
            Name = name;
            Switch = switch_;
        }
        #endregion

        #region Properties

        public string Switch { get; }
        #endregion 
    }
}
