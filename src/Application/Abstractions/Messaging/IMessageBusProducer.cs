namespace Application.Abstractions.Messaging;

public interface IMessageBusProducer
{
    Task Publish<T>(T message, CancellationToken cancellationToken) where T : class;
}