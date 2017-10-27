using System.Data.Entity;
using System.Windows.Controls;
using WpfApp.DbProvider;

namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ListViewSystem : UserControl
    {
        public ListViewSystem()
        {
            InitializeComponent();

            
            using (var context = new ReportContext("system"))
            {
                context.SystemTables.Load();

                ListViewList.ItemsSource = context.SystemTables.Local.ToBindingList();

                //var notifications = context.SystemNotificationGroups;
                //var cntNotif = notifications.Count();
            }
            //ListViewList.ItemsSource = list;
        }

        private void ListViewList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
