using Infrastructure.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Contexts;

internal class QuickDbContext(DbContextOptions<QuickDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TradeConfiguration());
    }
}