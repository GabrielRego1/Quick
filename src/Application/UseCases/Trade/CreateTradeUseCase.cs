using Application.Abstractions.Adapters;
using Application.Messages.Commands;
using Application.UseCases.Abstractions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trade;

public class CreateTradeUseCase(ILogger<CreateTradeUseCase> logger, ICreateTradeAdapter adapter) : ICreateTradeUseCase
{
    public async Task ExecuteAsync(CreateTradeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing {UseCase} with command: {Command}", nameof(CreateTradeUseCase), command);
        
        
        //ToDo: Check Asset is valid
        //ToDo: Update SettlemenmtAccount

        await adapter.CreateTrade(command, cancellationToken);
    }
}