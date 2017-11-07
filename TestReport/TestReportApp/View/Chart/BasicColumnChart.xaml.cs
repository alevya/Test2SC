using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using LiveCharts;
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
        public BasicColumnChart(IEnumerable dResult)
        {
            InitializeComponent();

            if(dResult == null) return;

            var enumerable = dResult as Dictionary<string, int>;
            if (enumerable != null)
            {
                SeriesCollection = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "",
                        Values = new ChartValues<int>(enumerable.Values),
                    }
                };
                Labels = enumerable.Keys.ToArray();
            }
            //Formatter = value => value.ToString("N");

            DataContext = this;
        }
    }
}
