using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.DbProvider;
using WpfApp.DbProvider.Models;

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

            //BindingList<SystemTables.SystemTable> list;
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
