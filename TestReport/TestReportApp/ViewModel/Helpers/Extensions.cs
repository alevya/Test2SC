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
                case ShapeCodeReport.LineChart:
                    var columnChart = new BasicColumnChart(source);
                    return columnChart;
                case ShapeCodeReport.TableChart:
                    return null;
                default:
                    return null;
            }

        }
    }
}
