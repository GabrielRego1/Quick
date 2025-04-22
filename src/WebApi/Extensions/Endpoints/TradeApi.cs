using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Extensions.Endpoints;

internal static class TradeApi
{
    private static readonly string[] DefaultTags = ["Trade"];

    internal static WebApplication MapTradeApi(this WebApplication app)
    {
        var group = app.MapGroup("/trade").WithTags(DefaultTags);

        group.MapPost("/", ([FromBody] Trade trade, [FromServices] ILogger<Trade> logger) =>
        {
            logger.LogInformation("Received trade request for ticker: {Ticker}", trade.Ticker);
            return Results.Ok(new { Id = Guid.NewGuid(), Ticker = trade.Ticker, Status = "Created" });
        });

        return app;
    }
}