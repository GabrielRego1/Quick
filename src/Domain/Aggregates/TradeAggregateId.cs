using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class TradeAggregateId : IAggregateId
{
    private Ticker Ticker { get; init; }
    private Account Account { get; init; }
    private Side Side { get; init; }

    private TradeAggregateId Create(Ticker ticker, Account account, Side side)
        => new()
        {
            Ticker = ticker,
            Account = account,
            Side = side
        };

    public string ParseToString()
        => $"{Ticker}-{Account}-{Side}";
}