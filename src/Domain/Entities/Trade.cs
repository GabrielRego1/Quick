using Domain.Enums;

namespace Domain.Entities;

public class Trade(
    string ticker,
    string account,
    Side side,
    decimal quantity,
    decimal price,
    DateOnly tradeDate)
{
    public string Ticker { get; private set; } = ticker;
    public string Account { get; private set; } = account;
    public string SettlementAccount { get; private set; }
    public Side Side { get; private set; } = side;
    public decimal Quantity { get; private set; } = quantity;
    public decimal Price { get; private set; } = price;
    public DateOnly TradeDate { get; private set; } = tradeDate;
    public TradeStatuses TradeStatus { get; private set; }

    public void UpdateSettlementAccount(string settlementAccount)
    {
        if (string.IsNullOrEmpty(settlementAccount))
            throw new ArgumentException("Invalid settlement account");

        SettlementAccount = settlementAccount;
    }

    public void SetStatusForSentToCreate()
        => TradeStatus = TradeStatuses.SentToCreate;
}