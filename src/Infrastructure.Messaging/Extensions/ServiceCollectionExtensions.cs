using System.Reflection;
using Application.Abstractions.Messaging;
using Application.Abstractions.Messaging.Publishers;
using Infrastructure.Messaging.Options;
using Infrastructure.Messaging.Publishers;
using Microsoft.Extensions.DependencyInjection;
using Application.Extensions;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Messaging.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessageBus(this IServiceCollection services)
        => services.AddPublishers()
            .ConfigureOptions<MessageBusOptions>(MessageBusOptions.ConfigurationPath)
            .AddMassTransit(bus =>
            {
                bus.UsingRabbitMq((context, cfg) =>
                {
                    var options = context.GetOptionsCurrentValue<MessageBusOptions>();
                    cfg.Host(options.ConnectionString);
                });
                bus.AddConsumers(Assembly.GetExecutingAssembly());
                bus.SetKebabCaseEndpointNameFormatter();
            });


    private static IServiceCollection AddPublishers(this IServiceCollection services)
        => services.AddTransient<IMessageBusProducer, MessageBusProducer>()
            .AddTransient<ITradePublisher, TradePublisher>();
}