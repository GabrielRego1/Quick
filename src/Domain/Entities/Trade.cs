using Domain.Abstractions;
using Domain.Aggregates;
using Domain.Enums;
using Domain.Events;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Trade : AggregateRoot<TradeAggregateId>
{
    public static Trade Iniciate(Ticker ticker,
        Account account,
        Account settlementAccount,
        Side side,
        Quantity quantity,
        Price price,
        DateOnly tradeDate)
    {
        return new Trade(ticker,
            account: account,
            settlementAccount: settlementAccount,
            side,
            quantity,
            price,
            tradeDate);
    }

    private Trade(Ticker ticker,
        Account account,
        Account settlementAccount,
        Side side,
        Quantity quantity,
        Price price,
        DateOnly tradeDate)
    {
        var @event = new TradeInitiated
        (
            ticker,
            account,
            settlementAccount,
            side,
            quantity,
            price,
            tradeDate,
            TradeStatus.Initiated
        );
        Raise(@event);
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

    private void Apply(TradeInitiated tradeInitiated)
    {
        Ticker = tradeInitiated.Ticker;
        Account = tradeInitiated.Account;
        SettlementAccount = tradeInitiated.SettlementAccount;
        Side = tradeInitiated.Side;
        Quantity = tradeInitiated.Quantity;
        Price = tradeInitiated.Price;
        TradeDate = tradeInitiated.TradeDate;
        TradeStatus = tradeInitiated.TradeStatus;
    }

    private void Apply(TradeSentToCreate tradeSentToCreate)
        => TradeStatus = tradeSentToCreate.TradeStatus;
}