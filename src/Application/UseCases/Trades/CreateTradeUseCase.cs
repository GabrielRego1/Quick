using Application.Abstractions.Adapters;
using Application.Abstractions.Repositories;
using Application.Messages.Commands;
using Application.Options;
using Application.UseCases.Abstractions;
using Application.Validations;
using Application.Validations.Commands;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trades;

public class CreateTradeUseCase(
    ILogger<CreateTradeUseCase> logger,
    ICreateTradeAdapter adapter,
    ITradeRepository tradeRepository,
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

        var trade = new Trade(command.Ticker, command.Account, command.Side, command.Quantity, command.Price, command.TradeDate);

        trade.UpdateSettlementAccount(settlementOptions.Account);

        await adapter.CreateTrade(trade, cancellationToken);

        trade.SetStatusForSentToCreate();
        
        await tradeRepository.AddAsync(trade);
        await tradeRepository.SaveChangesAsync();
    }
}