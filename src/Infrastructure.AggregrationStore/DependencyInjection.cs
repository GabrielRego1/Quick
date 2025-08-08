using Application.Abstractions.Gateways;
using Application.Extensions;
using Infrastructure.AggregrationStore.Abstractions;
using Infrastructure.AggregrationStore.Contexts;
using Infrastructure.AggregrationStore.Gateways;
using Infrastructure.AggregrationStore.Options;
using Infrastructure.AggregrationStore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.AggregrationStore;

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