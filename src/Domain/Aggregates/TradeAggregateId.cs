using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class TradeAggregateId : IAggregateId
{
    private string Ticker { get; init; }
    private string Account { get; init; }
    private Side Side { get; init; }

    public static TradeAggregateId Create(Trade trade)
        => new()
        {
            Ticker = trade.Ticker.Value,
            Account = trade.Account.Value,
            Side = trade.Side
        };

    public string ParseToString()
        => $"{Ticker}-{Account}-{Side}";
}