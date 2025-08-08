namespace Application.Abstractions.Gateways;

public interface IMessageBusGateway
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
}