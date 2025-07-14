using Application.Abstractions.Adapters;
using Application.Abstractions.Messaging.Publishers;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trades.Adapters;

public interface ICreateTradeRabbitMqAdapter : ICreateTradeAdapter;

public class CreateTradeRabbitMqAdapter(ITradePublisher publisher, ILogger<CreateTradeRabbitMqAdapter> logger)
    : ICreateTradeRabbitMqAdapter
{
    public async Task CreateTrade(Trade trade, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting publishing command {Command} to RabbitMQ", nameof(trade));
        await publisher.PublishAsync(trade, cancellationToken);
    }
}