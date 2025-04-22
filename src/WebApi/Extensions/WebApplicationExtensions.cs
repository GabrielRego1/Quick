using Scalar.AspNetCore;
using WebApi.Extensions.Endpoints;

namespace WebApi.Extensions;

internal static class WebApplicationExtensions
{
    internal static WebApplication UseScalar(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
        return app;
    }

    internal static WebApplication MapApplicationEndpoints(this WebApplication app)
        => app.MapSupportApi()
            .MapTradeApi();
}