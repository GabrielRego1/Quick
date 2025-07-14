using System.Reflection;
using Application.Abstractions.Messaging;
using Application.Abstractions.Messaging.Publishers;
using Application.Extensions;
using Infrastructure.Messaging.Options;
using Infrastructure.Messaging.Publishers;
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
        => services.AddTransient<IMessageBusProducer, MessageBusProducer>()
            .AddTransient<IPaymentPublisher, PaymentPublisher>()
            .AddTransient<ITradePublisher, TradePublisher>();
}