using Domain.Enums;

namespace Application.Messages.Commands;

public record CreateTradeCommand(string Ticker, string Account,string SettlementAccount, decimal Price, decimal Quantity, DateOnly TradeDate, Side Side);