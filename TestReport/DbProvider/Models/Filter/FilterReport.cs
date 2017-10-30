using System;
using System.Collections.Generic;

namespace TestReportApp.DbProvider.Models.Filter
{
    public class FilterReport
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

    public class FilterReportAdd : FilterReport
    {
        public IEnumerable<string> UsageValues { get; set; }
    }
}
