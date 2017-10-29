using System.Data.Entity;

namespace TestReportApp.DbProvider
{
    public interface IContextFactory<out TContext> where TContext : DbContext
    {
        TContext Create();
    }
}
