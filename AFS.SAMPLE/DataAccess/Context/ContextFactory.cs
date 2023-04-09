using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AFS.SAMPLE.DataAccess;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        const string connectionString = "";

        return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
    }
}
