using Microsoft.EntityFrameworkCore;

namespace TestWebApplication.Infrastructure.Persistence.Common;

public class PostgresApplicationDbContext : DbContext
{
    public PostgresApplicationDbContext(DbContextOptions<PostgresApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresApplicationDbContext).Assembly);
    }
}
