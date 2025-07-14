using Application.Abstractions.Messaging;
using Application.Abstractions.Messaging.Publishers;
using Domain.Entities;

namespace Infrastructure.Messaging.Publishers;

public class TradePublisher(IMessageBusProducer producer) : ITradePublisher
{
    public Task PublishAsync(Trade trade, CancellationToken cancellationToken)
        => producer.Publish(trade, cancellationToken);
}