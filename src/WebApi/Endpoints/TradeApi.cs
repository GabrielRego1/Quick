using Application.Messages.Commands;
using Application.UseCases.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints;

internal static class TradeApi
{
    private static readonly string[] DefaultTags = ["Trade"];

    internal static WebApplication MapTradeApi(this WebApplication app)
    {
        var group = app.MapGroup("/trade").WithTags(DefaultTags);

        group.MapPost("/",
            ([FromBody] CreateTradeCommand command, [FromServices] ICreateTradeUseCase useCase) =>
            {
                //ToDo: Repensar a forma de passar o CancellationToken
                //Todo: Melhorar o tratamento/retorno de erros de um caso de uso
                useCase.ExecuteAsync(command, CancellationToken.None);
            });

        return app;
    }
}