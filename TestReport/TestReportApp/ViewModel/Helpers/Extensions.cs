using System.Collections;
using System.Windows.Controls;
using TestReportApp.View.Chart;

namespace TestReportApp.ViewModel.Helpers
{
    public static class Extensions
    {
        internal static UserControl GetChartView(this IReportFilter vm, ShapeCodeReport shapeCode, IEnumerable source)
        {
            switch (shapeCode)
            {
                case ShapeCodeReport.ColumnChart:
                    return new BasicColumnChart(source);
                case ShapeCodeReport.PieChart:
                    return new BasicPieChart();
                case ShapeCodeReport.TableChart:
                case ShapeCodeReport.LineChart:
                default:
                    return null;
            }

        }
    }
}
