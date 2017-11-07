using System;
using System.Collections;
using System.Windows.Controls;
using TestReportApp.View.Chart;

namespace TestReportApp.ViewModel.Helpers
{
    public static class Extensions
    {
        internal static UserControl GetChartView(this IReportFilter vm, ShapeCodeReport shapeCode, IEnumerable source
            ,DateTime? dtFrom = null, DateTime? dtTo = null)
        {
            switch (shapeCode)
            {
                case ShapeCodeReport.ColumnChart:
                    return new BasicColumnChart(source); 
                case ShapeCodeReport.PieChart:
                    return new BasicPieChart(source);
                case ShapeCodeReport.TableChart:
                    return new BasicTableChart(source);
                case ShapeCodeReport.LineChart:
                    return new BasicLineChart(source, dtFrom, dtFrom);
                default:
                    return null;
            }

        }
    }
}
