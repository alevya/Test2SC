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

            //SeriesCollection = new SeriesCollection
            //                   {
            //                       new ColumnSeries
            //                       {
            //                           Title = "2015",
            //                           Values = new ChartValues<double> {10, 50, 39, 50}
            //                       },
            //                       new ColumnSeries
            //                       {
            //                           Title = "2016",
            //                           Values = new ChartValues<double> {11, 56, 42}
            //                       }
            //                   };

            ////adding series will update and animate the chart automatically

            ////also adding values updates and animates the chart automatically
            //SeriesCollection[1].Values.Add(48d);

            //Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            //Formatter = value => value.ToString("N");

            DataContext = this;
        }
    }
}
