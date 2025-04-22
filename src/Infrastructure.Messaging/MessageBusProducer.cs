using Application.Abstractions.Messaging;

namespace Infrastructure.Messaging;

public class MessageBusProducer : IMessageBusProducer
{
    public Task Publish<T>(T message, CancellationToken cancellationToken) where T : class
    {
        throw new NotImplementedException();
    }
}