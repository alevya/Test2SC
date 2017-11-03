namespace TestReportApp.ViewModel
{
    public interface IReportFilter
    {
        string Name { get; set; }
        void GetContent();
        void GetDataForReport();
    }
}
