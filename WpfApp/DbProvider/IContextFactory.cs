using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DbProvider
{
    public interface IContextFactory<out TContext> where TContext : DbContext
    {
        TContext Create();
    }
}
