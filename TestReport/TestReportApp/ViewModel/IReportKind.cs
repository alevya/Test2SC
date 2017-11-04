using System.Collections.ObjectModel;
using TestReportApp.ViewModel.Filter;

namespace TestReportApp.ViewModel
{
    internal interface IReportFilter
    {
        string Name { get; set; }
        ObservableCollection<ShapeReportViewModel> ShapesCodeReport { get; }
        ShapeReportViewModel CurrentShape { get; set; }

        void GetContent();
        void GetDataForReport();
    }
}
