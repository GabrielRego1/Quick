namespace WebApi.Endpoints;

internal static class EndpointsConfigurator
{
    internal static WebApplication MapApplicationEndpoints(this WebApplication app)
        => app.MapSupportApi()
            .MapTradeApi();
}