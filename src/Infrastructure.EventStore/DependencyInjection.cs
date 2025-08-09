using Application.Abstractions.Gateways;
using Application.Extensions;
using Infrastructure.EventStore.Abstractions;
using Infrastructure.EventStore.Contexts;
using Infrastructure.EventStore.Gateways;
using Infrastructure.EventStore.Options;
using Infrastructure.EventStore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EventStore;

public static class DependencyInjection
{
    public static IServiceCollection AddAggregrationStore(this IServiceCollection services)
        => services.AddDatabase()
            .AddRepositories()
            .AddGateways();

    private static IServiceCollection AddDatabase(this IServiceCollection services)
        => services.ConfigureOptions<EventStoreOptions>(EventStoreOptions.ConfigurationPath)
            .AddDbContext<EventStoreDbContext>((sp, optionsBuilder) =>
            {
                var eventStoreOptions = sp.GetRequiredService<EventStoreOptions>();
                optionsBuilder.UseSqlServer(eventStoreOptions.ConnectionString);
            });

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped<IAggregationStoreRepository, AggregationStoreRepository>();

    private static IServiceCollection AddGateways(this IServiceCollection services)
        => services.AddScoped<IAggregrationStoreGateway, AggregrationStoreGateway>();
}