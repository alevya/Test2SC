using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReportApp.ViewModel
{
    public interface IReportKind
    {
        string Name { get; set; }
        string Description { get; set; }
        bool IsSelected { get; set; }
        void GetContent();
    }
}
