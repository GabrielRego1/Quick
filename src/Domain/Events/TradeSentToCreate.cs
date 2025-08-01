using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Events;

public record TradeSentToCreate : IEvent
{
    public TradeStatus TradeStatus { get; init; } = TradeStatus.SentToCreate;
}