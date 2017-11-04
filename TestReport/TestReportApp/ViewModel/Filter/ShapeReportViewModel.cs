using System.Net.Sockets;
using System.Windows.Input;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel.Filter
{
    internal class ShapeReportViewModel : ViewModelBase
    {
        public static string GetName(ShapeCodeReport shapeCode)
        {
            switch (shapeCode)
            {
                case ShapeCodeReport.ColumnChart:
                    return "Столбчатая диаграмма";
                case ShapeCodeReport.LineChart:
                    return "Линейная диаграмма";
                case ShapeCodeReport.PieChart:
                    return "Круговая диаграмма";
                case ShapeCodeReport.TableChart:
                    return "Табличная диаграмма";
                default:
                    return string.Empty;
            }
        }

        public ShapeReportViewModel(ShapeCodeReport shapeCode)
        {
            ShapeReport = shapeCode;
            Name = GetName(shapeCode);
        }

        #region Properties

        public string Name { get;}
        public ShapeCodeReport ShapeReport { get; }

        #endregion

        
    }
}
