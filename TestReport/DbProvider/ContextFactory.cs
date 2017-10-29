using System.Data.Entity;

namespace TestReportApp.DbProvider
{
    public class ContextFactory : IContextFactory<DbContext>
    {

        private readonly string _connectionString;
        public ContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbContext Create()
        {

            return new ReportContext("z_october_2017");
        }
    }
}
