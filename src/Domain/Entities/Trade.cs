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

    public Trade Iniciate()
    {
        var trade = new Trade();
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
    public IEnumerable<(int version, IMessage message)> UncommittedMessages { get; }

    public void Load(IEnumerable<IMessage> messages)
    {
        throw new NotImplementedException();
    }
}