using Application.Extensions;
using Infrastructure.SqlServer.Abstractions;
using Infrastructure.SqlServer.Contexts;
using Infrastructure.SqlServer.Options;
using Infrastructure.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;   
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SqlServer;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        => services.ConfigureOptions<EventStoreOptions>(EventStoreOptions.ConfigurationPath)
            .AddDbContext<EventStoreDbContext>((sp, optionsBuilder) =>
            {
                var eventStoreOptions = sp.GetRequiredService<EventStoreOptions>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString(eventStoreOptions.ConnectionString));
            })
            .AddRepositories();

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped<IAggregationStoreRepository, AggregationStoreRepository>();
}