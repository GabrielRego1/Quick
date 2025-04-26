using Application.Abstractions.Adapters;
using Application.Abstractions.Services;
using Application.Messages.Commands;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Trade.Adapters;

public class CreateTradeHttpClientAdapter(IHttpService httpService, ILogger<CreateTradeHttpClientAdapter> logger)
    : ICreateTradeHttpClientAdapter
{
    public async Task ExecuteAsync(CreateTradeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting sending HTTP POST request {Command} to WebAPI", nameof(command));
        var response = await httpService.PostAsJsonAsync("/api/trade", command, cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}