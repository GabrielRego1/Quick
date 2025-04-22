using Application.Abstractions.Messaging.Publishers;
using Domain.Entities;

namespace Infrastructure.Messaging.Publishers;

public class TradePublisher : ITradePublisher
{
    public Task PublishAsync(Trade trade, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}