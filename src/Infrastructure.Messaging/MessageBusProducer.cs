using Application.Abstractions.Messaging;
using MassTransit;

namespace Infrastructure.Messaging;

internal class MessageBusProducer(IPublishEndpoint publishEndpoint) : IMessageBusProducer
{
    public Task Publish<T>(T message, CancellationToken cancellationToken)
        => publishEndpoint.Publish(message, cancellationToken);
}