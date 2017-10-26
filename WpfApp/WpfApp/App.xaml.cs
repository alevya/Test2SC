using System.Linq;
using System.Windows;
using WpfApp.DbProvider;
using WpfApp.DbProvider.Models;
using WpfApp.View;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Init

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //using (var context = new ReportContext("z_october_2017"))
            //{
            //    var d = context.CorrelationsAwareness;
            //    var cnt = d.Count();
            //    foreach (var c in d)
            //    {

            //    }
            //}

            //using (var context = new ReportContext("system"))
            //{
            //    var sources = context.SystemTables;
            //    var cnt = sources.Count();

            //    var notifications = context.SystemNotificationGroups;
            //    var cntNotif = notifications.Count();
            //}

            var main = new MainView();
            main.Show();
            
            
        }

        #endregion
    }

    
}
