namespace Application.Messages.Commands;

public record CreateTradeCommand(string Ticker, string Account, decimal Price, decimal Quantity) : IMessage;