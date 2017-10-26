using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Reflection;
using MySql.Data.Entity;
using WpfApp.DbProvider.Models;

namespace WpfApp.DbProvider
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ReportContext : DbContext
    {
        //public ReportContext() : base()
        //{
            
        //}
       
        public ReportContext(string dbName) : base(FormatConnectionString(dbName))
        {
            
        }


        public DbSet<Correlation.CorrelationSuspicious> CorrelationsSuspicious { get; set; }
        public DbSet<Correlation.CorrelationSuspiciousHigh> CorrelationsSuspiciousHigh { get; set; }
        public DbSet<Correlation.CorrelationAwareness> CorrelationsAwareness { get; set; }
        public DbSet<Correlation.CorrelationAwarenessHigh> CorrelationsAwarenessHigh { get; set; }
        public DbSet<Correlation.CorrelationAnalyze> CorrelationsAnalyze { get; set; }

        //public DbSet<SystemTable> SystemTables { get; set; }
        //public DbSet<SystemNotificationGroup> SystemNotificationGroups { get; set; }


        public static string FormatConnectionString(string dbName)
        {
            //var config = ConfigurationManager.OpenExeConfiguration(AppDomain.CurrentDomain.BaseDirectory +
            //                                          Assembly.GetCallingAssembly().GetName());

            //var cSecion = config.GetSection("connectionStrings") as ConnectionStringsSection;
            //string connectionString = cSecion.ConnectionStrings["SecurityCapsuleConsole.ConnectionString"].ConnectionString;
            // cSecion.C
            var connectionString =
                ConfigurationManager.ConnectionStrings["SecurityCapsuleConsole"].ConnectionString;

            var joinStr = string.Join(";", connectionString, "DataBase={0}");
            return string.Format(joinStr, dbName);
        }
    }
}
