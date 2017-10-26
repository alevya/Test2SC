using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.Entity;
using WpfApp.DbProvider;
using WpfApp.DbProvider.Models;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class App : Application
    {

        #region Init

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
          
            var context = new ReportContext("z_october_2017");
            var d = context.CorrelationsAwareness;
            var cnt = d.Count();
            foreach (var c in d)
            {

            }
        }

        #endregion
    }

    
}
