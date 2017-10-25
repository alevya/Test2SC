using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Reflection;
using MySql.Data.Entity;

namespace WpfApp.DbProvider
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ReportContext : DbContext
    {
        public ReportContext()
        {
            //ConfigurationManager.OpenExeConfiguration(AppDomain.CurrentDomain.BaseDirectory +
            //                                          Assembly.GetCallingAssembly().GetName());
        }

        public ReportContext(DbConnection existingDbConnection, bool contextOwnsConnection) : base(existingDbConnection, contextOwnsConnection)
        {

        }

        //public DbSet<CorrelationSuspicious> CorrelationsSuspicious { get; set; }
        //public DbSet<CorrelationSuspiciousHigh> CorrelationsSuspiciousHigh { get; set; }
        //public DbSet<CorrelationAwareness> CorrelationsAwareness { get; set; }
        //public DbSet<CorrelationAwarenessHigh> CorrelationsAwarenessHigh { get; set; }
        //public DbSet<CorrelationAnalyze> CorrelationsAnalyze { get; set; }

        //public DbSet<SystemTable> SystemTables { get; set; }
        //public DbSet<SystemNotificationGroup> SystemNotificationGroups { get; set; }


        //public static string FormatConnectionString(string dbName)
        //{
        //    var config = ConfigurationManager.OpenExeConfiguration(AppDomain.CurrentDomain.BaseDirectory +
        //                                              Assembly.GetCallingAssembly().GetName());
        //    var cSecion = config.GetSection("connectionStrings") as ConnectionStringsSection;
        //    string connectionString = cSecion.ConnectionStrings["SecurityCapsuleConsole.Properties.Notifications.connectionString"].ConnectionString;
        //   // cSecion.C

        //    var joinStr = string.Join(";", connectionString, "DataBase={0}");
        //    return string.Format(joinStr, dbName);
        //}
    }
}
