using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace TestReportApp.View.Chart
{
    /// <summary>
    /// Логика взаимодействия для BasicPieChart.xaml
    /// </summary>
    public partial class BasicPieChart : UserControl
    {
        public Func<ChartPoint, string> PointLabel { get; set; }

        public BasicPieChart()
        {
            InitializeComponent();

            PointLabel = chartPoint =>
                $"{chartPoint.Y} ({chartPoint.Participation:P})";

            DataContext = this;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (var seriesView in chart.Series)
            {
                var series = (PieSeries) seriesView;
                series.PushOut = 0;
            }

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
