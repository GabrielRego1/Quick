using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureOptions<T>(this IServiceCollection services, string configureOptions)
        where T : class
        => services.AddOptions<T>()
            .BindConfiguration(configureOptions)
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services;
}