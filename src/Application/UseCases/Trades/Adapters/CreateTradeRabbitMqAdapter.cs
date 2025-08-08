using Application.Abstractions.Adapters;
using Application.Abstractions.Gateways;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trades.Adapters;

public interface ICreateTradeRabbitMqAdapter : ICreateTradeAdapter;

public class CreateTradeRabbitMqAdapter(
    IMessageBusGateway messageBusGateway,
    ILogger<CreateTradeRabbitMqAdapter> logger)
    : ICreateTradeRabbitMqAdapter
{
    public async Task CreateTrade(Trade trade, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting publishing command {Command} to RabbitMQ", nameof(trade));
        await messageBusGateway.PublishAsync(trade, cancellationToken);
    }
}