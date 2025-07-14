using Application.Abstractions.Adapters;
using Application.Abstractions.Repositories;
using Application.Messages.Commands;
using Application.Options;
using Application.UseCases.Abstractions;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trades;

public class CreateTradeUseCase(
    ILogger<CreateTradeUseCase> logger,
    ICreateTradeAdapter adapter,
    ITradeRepository tradeRepository,
    SettlementOptions settlementOptions) : ICreateTradeUseCase
{
    public async Task ExecuteAsync(CreateTradeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing {UseCase} with command: {Command}", nameof(CreateTradeUseCase), command);

        if (!IsValidTrade(command))
        {
            logger.LogWarning("Invalid trade command: {Command}", command);
            throw new ArgumentException("Invalid trade command");
        }

        var trade = new Trade(command.Ticker, command.Account, command.Side, command.Quantity, command.Price, command.TradeDate);

        trade.UpdateSettlmentAccount(settlementOptions.Account);

        await adapter.CreateTrade(trade, cancellationToken);

        trade.SetStatusForSentToCreate();
        await tradeRepository.AddAsync(trade);
    }


    private bool IsValidTrade(CreateTradeCommand command)
    {
        // Implement validation logic for the trade
        return true;
    }
}