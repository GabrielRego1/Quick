using Application.Abstractions.Adapters;
using Application.Abstractions.Services;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trades.Adapters;

public interface ICreateTradeHttpClientAdapter : ICreateTradeAdapter;

public class CreateTradeHttpClientAdapter(IHttpService httpService, ILogger<CreateTradeHttpClientAdapter> logger)
    : ICreateTradeHttpClientAdapter
{
    public async Task CreateTrade(Trade trade, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting sending HTTP POST request {Command} to WebAPI", nameof(trade));
        var response = await httpService.PostAsJsonAsync("/api/trade", trade, cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}