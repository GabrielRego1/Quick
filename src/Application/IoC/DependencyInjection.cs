using Application.Abstractions.Adapters;
using Application.Abstractions.Services;
using Application.Extensions;
using Application.Options;
using Application.Services.Http;
using Application.UseCases.Abstractions;
using Application.UseCases.Payment.Interactors;
using Application.UseCases.Trade;
using Application.UseCases.Trade.Adapters;
using Application.UseCases.Trade.Interactors;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services.AddInteractors()
            .AddUseCases()
            .AddHttpServices()
            .AddAdapters();

    private static IServiceCollection AddHttpServices(this IServiceCollection services)
        => services.AddHttpClient<IHttpService, HttpService>()
            .AddStandardResilienceHandler()
            .Services; //ToDo: melhorar a resiliência em chamadas HTTP

    private static IServiceCollection AddInteractors(this IServiceCollection services)
        => services.AddScoped<ITradeCreatedInteractor, TradeCreatedInteractor>()
            .AddScoped<IPaymentCreatedInteractor, PaymentCreatedInteractor>();

    private static IServiceCollection AddUseCases(this IServiceCollection services)
        => services.AddScoped<ICreateTradeUseCase, CreateTradeUseCase>();

    private static IServiceCollection AddAdapters(this IServiceCollection services)
        => services.AddTradeCreateAdapters();

    private static IServiceCollection AddTradeCreateAdapters(this IServiceCollection services)
        => services.ConfigureOptions<CreateTradeAdapterOptions>(CreateTradeAdapterOptions.ConfigurationPath)
            .AddScoped<ICreateTradeHttpClientAdapter, CreateTradeHttpClientAdapter>()
            .AddScoped<ICreateTradeRabbitMqAdapter, CreateTradeRabbitMqAdapter>()
            .AddScoped<ICreateTradeAdapter>(provider =>
            {
                var options = provider.GetOptionsCurrentValue<CreateTradeAdapterOptions>();
                return options.AdapterType switch
                {
                    "HttpClient" => provider.GetRequiredService<CreateTradeHttpClientAdapter>(),
                    "RabbitMq" => provider.GetRequiredService<CreateTradeRabbitMqAdapter>(),
                    _ => throw new InvalidOperationException("Invalid adapter type configured.")
                };
            });
}