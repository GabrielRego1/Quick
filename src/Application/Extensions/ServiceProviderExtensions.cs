using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Application.Extensions;

public static class ServiceProviderExtensions
{
    public static T GetOptionsCurrentValue<T>(this IServiceProvider provider)
        => provider.GetRequiredService<IOptionsMonitor<T>>().CurrentValue;
}