using System.Reflection;
using Application.Abstractions.Gateways;
using Application.Extensions;
using Infrastructure.Messaging.Gateways;
using Infrastructure.Messaging.Options;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Messaging;

public static class DependencyInjection
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
                    cfg.ConfigureEndpoints(context);
                });
                bus.AddConsumers(Assembly.GetExecutingAssembly());
                bus.SetKebabCaseEndpointNameFormatter();
            });


    private static IServiceCollection AddPublishers(this IServiceCollection services)
        => services.AddTransient<IMessageBusGateway, MessageBusGateway>();
}