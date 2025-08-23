using Application.Abstractions.Adapters;
using Application.Abstractions.Services;
using Application.Extensions;
using Application.Options;
using Application.Services;
using Application.Services.Http;
using Application.UseCases.Abstractions;
using Application.UseCases.Payments.Interactors;
using Application.UseCases.Trades;
using Application.UseCases.Trades.Adapters;
using Application.UseCases.Trades.Interactors;
using Application.Validations;
using Application.Validations.Commands;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services.AddInteractors()
            .AddUseCases()
            .AddHttpServices()
            .AddOptions()
            .AddAdapters()
            .AddValidators()
            .AddServices();

    private static IServiceCollection AddUseCases(this IServiceCollection services)
        => services.AddScoped<ICreateTradeUseCase, CreateTradeUseCase>();

    private static IServiceCollection AddHttpServices(this IServiceCollection services)
        => services.AddHttpClient<IHttpService, HttpService>()
            .AddStandardResilienceHandler()
            .Services; //ToDo: melhorar a resiliência em chamadas HTTP

    private static IServiceCollection AddInteractors(this IServiceCollection services)
        => services.AddScoped<ITradeInitiatedInteractor, TradeInitiatedInteractor>()
            .AddScoped<IPaymentCreatedInteractor, PaymentCreatedInteractor>();

    private static IServiceCollection AddAdapters(this IServiceCollection services)
        => services.AddTradeCreateAdapters();

    private static IServiceCollection AddOptions(this IServiceCollection services)
        => services.ConfigureOptions<CreateTradeAdapterOptions>(CreateTradeAdapterOptions.ConfigurationPath)
            .ConfigureOptions<SettlementOptions>(SettlementOptions.ConfigurationPath);

    private static IServiceCollection AddTradeCreateAdapters(this IServiceCollection services)
        => services.AddScoped<ICreateTradeHttpClientAdapter, CreateTradeHttpClientAdapter>()
            .AddScoped<ICreateTradeRabbitMqAdapter, CreateTradeRabbitMqAdapter>()
            .AddScoped<ICreateTradeAdapter>(provider =>
            {
                var options = provider.GetOptionsCurrentValue<CreateTradeAdapterOptions>();
                return options.AdapterType switch
                {
                    "HttpClient" => provider.GetRequiredService<ICreateTradeHttpClientAdapter>(),
                    "RabbitMq" => provider.GetRequiredService<ICreateTradeRabbitMqAdapter>(),
                    _ => throw new InvalidOperationException("Invalid adapter type configured.")
                };
            });

    private static IServiceCollection AddValidators(this IServiceCollection services)
        => services.AddScoped(typeof(Validator<>))
            .AddValidatorsFromAssemblyContaining<CreateTradeCommandValidator>();

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IAggregrationService, AggregrationService>();
}