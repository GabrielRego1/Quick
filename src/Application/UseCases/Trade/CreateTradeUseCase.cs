using Application.Abstractions.Messaging.Publishers;
using Application.Messages.Commands;
using Application.UseCases.Abstractions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trade;

public class CreateTradeUseCase(ILogger<CreateTradeUseCase> logger, ITradePublisher publisher) : ICreateTradeUseCase
{
    public async Task ExecuteAsync(CreateTradeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing {UseCase} with command: {Command}", nameof(CreateTradeUseCase), command);

        await publisher.PublishAsync(command, cancellationToken);
    }
}