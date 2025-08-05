using Domain.Abstractions;
using Domain.Aggregates;
using Domain.Enums;
using Domain.Events;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Trade : AggregateRoot
{
    private Trade()
    {
    }

    public static Trade Iniciate(Ticker ticker,
        Account account,
        Account settlementAccount,
        Side side,
        Quantity quantity,
        Price price,
        DateOnly tradeDate)
    {
        var @event = new TradeAccepted
        (
            ticker,
            account,
            settlementAccount,
            side,
            quantity,
            price,
            tradeDate,
            Enums.TradeStatus.Accepted
        );
        var trade = new Trade();
        trade.Apply(@event);
        return trade;
    }

    public Ticker Ticker { get; private set; }
    public Account Account { get; private set; }
    public Account SettlementAccount { get; private set; }
    public Side Side { get; private set; }
    public Quantity Quantity { get; private set; }
    public Price Price { get; private set; }
    public DateOnly TradeDate { get; private set; }
    public TradeStatus TradeStatus { get; private set; }
    public Payment Payment { get; private set; }


    public void SetStatusForSentToCreate()
        => TradeStatus = TradeStatus.SentToCreate;

    protected override void Apply(IEvent @event)
        => Apply((dynamic)@event);

    private void Apply(TradeAccepted tradeAccepted)
    {
        Ticker = tradeAccepted.Ticker;
        Account = tradeAccepted.Account;
        SettlementAccount = tradeAccepted.SettlementAccount;
        Side = tradeAccepted.Side;
        Quantity = tradeAccepted.Quantity;
        Price = tradeAccepted.Price;
        TradeDate = tradeAccepted.TradeDate;
        TradeStatus = tradeAccepted.TradeStatus;
    }

    private void Apply(TradeSentToCreate tradeSentToCreate)
        => TradeStatus = tradeSentToCreate.TradeStatus;
}