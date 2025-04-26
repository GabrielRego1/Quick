namespace WebApi.Endpoints;

internal static class SupportApi
{
    private static readonly string[] DefaultTags = ["Support"];

    internal static WebApplication MapSupportApi(this WebApplication app)
    {
        var group = app.MapGroup("/support").WithTags(DefaultTags);

        group.MapGet("/configs", (IConfiguration config) =>
            config.AsEnumerable()
                .Select(kvp => new { kvp.Key, kvp.Value })
                .ToList()
        );

        return app;
    }
}