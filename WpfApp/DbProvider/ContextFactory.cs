using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DbProvider
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
