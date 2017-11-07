using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            var items = new List<Item<string, int>>();
            var enumerable = source as Dictionary<string, int>;
            if (enumerable != null)
            {
                items.AddRange(enumerable.Select(i => new Item<string, int>
                {
                    Name = i.Key,
                    Value = i.Value
                }));
            }
            ItemsGrid.ItemsSource = items;
        }

        public class Item<T,TV>
        {
            public T Name { get; set; }
            public TV Value { get; set; }
        }
    }
}
