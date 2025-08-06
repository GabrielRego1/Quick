using Infrastructure.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Contexts;

public class EventStoreDbContext(DbContextOptions<EventStoreDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventStoreDbContext).Assembly);

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder.Properties<string>().AreUnicode(false);
}