using Application.Abstractions.Gateways;
using MassTransit;

namespace Infrastructure.Messaging.Gateways;

public class MessageBusGateway(IPublishEndpoint publishEndpoint) : IMessageBusGateway
{
    public Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class
        => publishEndpoint.Publish(message, cancellationToken);
}