using Domain.Entities;

namespace Application.Abstractions.Messaging.Publishers;

public interface ITradePublisher
{
    Task PublishAsync(Trade trade, CancellationToken cancellationToken);
}