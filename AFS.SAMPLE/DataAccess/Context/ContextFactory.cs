using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AFS.SAMPLE.DataAccess;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        const string connectionString = "Server=162.55.111.198;Database=AFS.SAMPLE;User Id=afs;Password=@35J7wn35$*4;Integrated Security=false;MultipleActiveResultSets=true;TrustServerCertificate=Yes";

        return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
    }
}
