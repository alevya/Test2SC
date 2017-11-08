using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace TestReportApp.View.Chart
{
    /// <summary>
    /// Логика взаимодействия для BasicPieChart.xaml
    /// </summary>
    public partial class BasicPieChart : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

        public BasicPieChart(IEnumerable source)
        {
            InitializeComponent();

            if (source == null) return;

            var enumerable = source as Dictionary<string, List<DateTime>>;
            if (enumerable != null)
            {
                SeriesCollection = new SeriesCollection();
                foreach (var item in enumerable)
                {
                    var ser = new PieSeries
                    {
                        Title = item.Key,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(item.Value.Count) },
                        DataLabels = true,
                    };
                    SeriesCollection.Add(ser);
                }
            }

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
            selectedSeries.PushOut = 15;
        }
    }
}
