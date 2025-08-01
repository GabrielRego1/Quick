using Domain.Abstractions;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Events;

public record TradeAccepted(
    Ticker Ticker,
    Account Account,
    Account SettlementAccount,
    Side Side,
    Quantity Quantity,
    Price Price,
    DateOnly TradeDate,
    TradeStatus TradeStatus) : IEvent;