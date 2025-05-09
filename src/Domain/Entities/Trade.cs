using Domain.Enums;

namespace Domain.Entities;

public class Trade
{
    public string Ticker { get; set; }
    public string Account { get; set; }
    public Side Side { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public DateOnly TradeDate { get; set; }
}