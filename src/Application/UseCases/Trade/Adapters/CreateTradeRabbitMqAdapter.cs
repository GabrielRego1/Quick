using Application.Abstractions.Adapters;
using Application.Abstractions.Messaging.Publishers;
using Application.Messages.Commands;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trade.Adapters;

public interface ICreateTradeRabbitMqAdapter : ICreateTradeAdapter;
public class CreateTradeRabbitMqAdapter(ITradePublisher publisher, ILogger<CreateTradeRabbitMqAdapter> logger)
    : ICreateTradeRabbitMqAdapter
{
    public async Task ExecuteAsync(CreateTradeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting publishing command {Command} to RabbitMQ", nameof(command));
        await publisher.PublishAsync(command, cancellationToken);
    }
}