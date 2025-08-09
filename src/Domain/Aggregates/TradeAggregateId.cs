using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class TradeAggregateId : IAggregateId
{
    private Ticker Ticker { get; init; }
    private Account Account { get; init; }
    private Side Side { get; init; }

    public static TradeAggregateId Create(Trade trade)
        => new()
        {
            Ticker = trade.Ticker,
            Account = trade.Account,
            Side = trade.Side
        };

    public string ParseToString()
        => $"{Ticker}-{Account}-{Side}";
}