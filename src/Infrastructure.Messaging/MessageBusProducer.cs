using Application.Abstractions.Messaging;
using Application.Messages;
using MassTransit;

namespace Infrastructure.Messaging;

internal class MessageBusProducer(IPublishEndpoint publishEndpoint) : IMessageBusProducer
{
    public Task Publish<T>(T message, CancellationToken cancellationToken) where T : IMessage
        => publishEndpoint.Publish(message, cancellationToken);
}