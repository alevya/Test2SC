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
    /// Логика взаимодействия для BasicColumnChart.xaml
    /// </summary>
    public partial class BasicColumnChart : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public BasicColumnChart(IEnumerable source)
        {
            InitializeComponent();

            if(source == null) return;

            var enumerable = source as Dictionary<string, List<DateTime>>;
            if (enumerable != null)
            {
                SeriesCollection = new SeriesCollection();
                foreach (var item in enumerable)
                {
                    var ser = new ColumnSeries
                    {
                        Title = item.Key,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(item.Value.Count) },
                        DataLabels = true,
                    };
                    SeriesCollection.Add(ser);
                }

                Labels = enumerable.Keys.ToArray();
            }
            //Formatter = value => value.ToString("N");

            DataContext = this;
        }
    }


}
