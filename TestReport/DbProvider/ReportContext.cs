using System.Configuration;
using System.Data;
using System.Data.Entity;
using MySql.Data.Entity;
using TestReportApp.DbProvider.Models;

namespace TestReportApp.DbProvider
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ReportContext : DbContext
    {  
        
        public ReportContext(string dbName) : base(FormatConnectionString(dbName))
        {
            if (!Database.Exists())
            {
                Database.SetInitializer(new NullDatabaseInitializer<ReportContext>());
            }
            else
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<ReportContext>());
            }
        }

        public DbSet<SystemTables.SystemTable> SystemTables { get; set; }
        public DbSet<SystemTables.SystemNotificationGroup> SystemNotificationGroups { get; set; }

        public static string FormatConnectionString(string dbName)
        {
            var connectionString =
                ConfigurationManager.ConnectionStrings["SecurityCapsuleConsole"].ConnectionString;

            var joinStr = string.Join(";", connectionString, "DataBase={0}");
            return string.Format(joinStr, dbName);
        }
    }
}
