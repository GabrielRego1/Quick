using Domain.Abstractions;
using Domain.Aggregates;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Trade : IAggregateRoot
{
    private Trade()
    {
    }

    public static Trade Iniciate(Ticker ticker, Account account, Account settlementAccount, Side side, Quantity quantity, Price price, DateOnly tradeDate)
    {
        var trade = new Trade
        {
            Ticker = ticker,
            Account = account,
            SettlementAccount = settlementAccount,
            Side = side,
            Quantity = quantity,
            Price = price,
            TradeDate = tradeDate,
            TradeStatus = TradeStatuses.Accepted
        };
        return trade;
    }

    public Ticker Ticker { get; private set; }
    public Account Account { get; private set; }
    public Account SettlementAccount { get; private set; }
    public Side Side { get; private set; }
    public Quantity Quantity { get; private set; }
    public Price Price { get; private set; }
    public DateOnly TradeDate { get; private set; }
    public TradeStatuses TradeStatus { get; private set; }


    public void SetStatusForSentToCreate()
        => TradeStatus = TradeStatuses.SentToCreate;

    public int Version { get; }
    public IEnumerable<(int version, IEvent @event)> uncommittedEvents { get; }

    public void Load(IEnumerable<IEvent> messages)
    {
        throw new NotImplementedException();
    }
}