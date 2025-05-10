using Domain.Enums;

namespace Domain.Entities;

public class Trade
{
    public string Ticker { get; private set; }
    public string Account { get; private set; }
    public string SettlmentAccount { get; private set; }
    public Side Side { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal Price { get; private set; }
    public DateOnly TradeDate { get; private set; }

    public Trade(string ticker, string account, string settlmentAccount, Side side, decimal quantity, decimal price,
        DateOnly tradeDate)
    {
        Ticker = ticker;
        Account = account;
        SettlmentAccount = settlmentAccount;
        Side = side;
        Quantity = quantity;
        Price = price;
        TradeDate = tradeDate;
    }

    public void UpdateSettlmentAccount(string settlmentAccount)
    {
        if (string.IsNullOrEmpty(settlmentAccount))
            throw new ArgumentException("Invalid settlement account");

        SettlmentAccount = settlmentAccount;
    }
}