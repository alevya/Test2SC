using System.Collections;
using System.Windows.Controls;


namespace TestReportApp.View.Chart
{
    /// <summary>
    /// Логика взаимодействия для BasicTableChart.xaml
    /// </summary>
    public partial class BasicTableChart : UserControl
    {
        public string[] Columns { get; set; }

        public BasicTableChart(IEnumerable source)
        {
            InitializeComponent();

            if (source == null) return;
            var items = source as IDictionary;
            ItemsGrid.ItemsSource = items?.Values;
        }
    }
}
