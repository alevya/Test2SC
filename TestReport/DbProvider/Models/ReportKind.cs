using System.ComponentModel.Design;
using TestReportApp.DbProvider.Models.Filter;

namespace TestReportApp.DbProvider.Models
{
    public class ReportKind
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public bool IsSelected { get; set; }
        public FilterReport Filter { get; set; }
    }
}
