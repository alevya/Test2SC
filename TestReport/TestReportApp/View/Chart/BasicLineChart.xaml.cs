using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using TestReportApp.Annotations;

namespace TestReportApp.View.Chart
{
    /// <summary>
    /// Логика взаимодействия для BasicLineChart.xaml
    /// </summary>
    public partial class BasicLineChart : UserControl, INotifyPropertyChanged
    {
        private ZoomingOptions _zoomingMode;
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public BasicLineChart(IEnumerable source, DateTime? dtFrom, DateTime? dtTo)
        {
            InitializeComponent();


            if (dtFrom == null || dtTo == null || dtFrom >= dtTo) return;
            if (source == null) return;

            var enumerable = source as Dictionary<string, int>;
            if (enumerable != null)
            {
                SeriesCollection = new SeriesCollection();

                foreach (var item in enumerable)
                {
                    var ser = new LineSeries
                    {
                        Title = item.Key,
                        Values = GetData(dtFrom.Value, dtTo.Value, new[] { item.Value }),
                        StrokeThickness = 1,
                        Fill = Brushes.Transparent,
                    };
                    SeriesCollection.Add(ser);
                }
            }

            ZoomingMode = ZoomingOptions.X;
            XFormatter = val => new DateTime((long)val).ToString("dd MMM");
            YFormatter = val => val.ToString("N1");

            DataContext = this;
        }
        public ZoomingOptions ZoomingMode
        {
            get => _zoomingMode;
            set
            {
                _zoomingMode = value;
                OnPropertyChanged();
            }
        }

        private void ToogleZoomingMode(object sender, RoutedEventArgs e)
        {
            switch (ZoomingMode)
            {
                case ZoomingOptions.None:
                    ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    ZoomingMode = ZoomingOptions.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private ChartValues<DateTimePoint> GetData(DateTime dtFrom, DateTime dtTo, int[] source)
        {
            var values = new ChartValues<DateTimePoint>();
            var tSpan = dtTo - dtFrom;
            int qDays = tSpan.Days;

            for (var i = 0; i < qDays; i++)
            {
                values.Add(new DateTimePoint(dtFrom.AddDays(i), source[0]));
            }
            
            return values;
        }

        private void ResetZoomOnClick(object sender, RoutedEventArgs e)
        {

            X.MinValue = double.NaN;
            X.MaxValue = double.NaN;
            Y.MinValue = double.NaN;
            Y.MaxValue = double.NaN;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ZoomingModeCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            switch ((ZoomingOptions) value)
            {
                case ZoomingOptions.None:
                    return "Отсутствует";
                case ZoomingOptions.X:
                    return "X";
                case ZoomingOptions.Y:
                    return "Y";
                case ZoomingOptions.Xy:
                    return "XY";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
