using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class TradeAggregateId : IAggregateId
{
    private Ticker Ticker { get; set; }
    private Account Account { get; set; }
    private Side Side { get; set; }

    private TradeAggregateId Create(Ticker ticker, Account account, Side side)
        => new()
        {
            Ticker = ticker,
            Account = account,
            Side = side
        };
}