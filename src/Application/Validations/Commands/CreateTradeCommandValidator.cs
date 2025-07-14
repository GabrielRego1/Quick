using Application.Messages.Commands;
using FluentValidation;

namespace Application.Validations.Commands;

public class CreateTradeCommandValidator : AbstractValidator<CreateTradeCommand>
{
    public CreateTradeCommandValidator()
    {
        RuleFor(command => command.Ticker)
            .NotEmpty().WithMessage("Ticker cannot be empty.")
            .Length(1, 12).WithMessage("Ticker must be between 1 and 12 characters.");

        RuleFor(command => command.Account)
            .NotEmpty().WithMessage("Account cannot be empty.");

        RuleFor(command => command.Side)
            .IsInEnum().WithMessage("Side must be a valid value.");

        RuleFor(command => command.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(command => command.TradeDate)
            .NotEmpty().WithMessage("TradeDate cannot be empty.");
    }
}