using Scalar.AspNetCore;

namespace WebApi.Extensions;

internal static class WebApplicationExtensions
{
    internal static WebApplication UseScalar(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
        return app;
    }
}