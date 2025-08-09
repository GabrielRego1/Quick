using Domain.Serialization;
using Infrastructure.EventStore.Contexts;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApi.Extensions;

public static class HealthCheckExtensions
{
    public static IHealthChecksBuilder AddHealthCheck(this IServiceCollection services)
        => services.AddHealthChecks()
            .AddDbContextCheck<EventStoreDbContext>();

    public static IApplicationBuilder MapHealthChecks(this WebApplication app)
        => app.UseHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = async (context, report) =>
            {
                var result = new
                {
                    status = report.Status.ToString(),
                    checks = report.Entries.Select(e => new
                    {
                        name = e.Key,
                        status = e.Value.Status.ToString(),
                        exception = e.Value.Exception?.Message,
                        stacktrace = e.Value.Exception?.StackTrace,
                        description = e.Value.Description,
                        data = e.Value.Data
                    })
                };

                context.Response.StatusCode = report.Status == HealthStatus.Healthy
                    ? StatusCodes.Status200OK
                    : StatusCodes.Status503ServiceUnavailable;

                await context.Response.WriteAsJsonAsync(result, SerializationDefinitions.Default, cancellationToken: context.RequestAborted);
            }
        });
}