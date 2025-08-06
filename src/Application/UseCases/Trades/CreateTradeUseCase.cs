using Application.Messages.Commands;
using Application.Options;
using Application.UseCases.Abstractions;
using Application.Validations;
using Application.Validations.Commands;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trades;

public class CreateTradeUseCase(
    ILogger<CreateTradeUseCase> logger,
    SettlementOptions settlementOptions,
    Validator<CreateTradeCommand> validator) : ICreateTradeUseCase
{
    public async Task ExecuteAsync(CreateTradeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing {UseCase} with command: {Command}", nameof(CreateTradeUseCase), command);

        if (!validator.Validate(command, new CreateTradeCommandValidator()))
        {
            logger.LogWarning("Invalid trade command: {Command}", command);
            throw new ArgumentException("Invalid trade command");
        }

        if (!ShouldIniciateTrade(command))
        {
            logger.LogWarning("Trade with trade value higher than max value {MaxTradeValue}. Command: {Command}",
                settlementOptions.MaxTradeValue, command);
            throw new ArgumentException("Invalid trade command");
        }


        var trade = Trade.Iniciate(new Ticker(command.Ticker),
            account: new Account(command.Account),
            settlementAccount: new Account(command.SettlementAccount),
            command.Side,
            new Quantity(command.Quantity),
            new Price(command.Price),
            command.TradeDate);
    }

    private bool ShouldIniciateTrade(CreateTradeCommand command)
        => (command.Price * command.Quantity) <= settlementOptions.MaxTradeValue;
}