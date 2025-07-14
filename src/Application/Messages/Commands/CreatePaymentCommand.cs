namespace Application.Messages.Commands;

public record CreatePaymentCommand(string Account, decimal Price, DateOnly PaymentDate);