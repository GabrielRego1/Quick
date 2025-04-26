namespace WebApi.Endpoints;

public static class EndpointsConfigurator
{
    internal static WebApplication MapApplicationEndpoints(this WebApplication app)
        => app.MapSupportApi()
            .MapTradeApi();
}