using Application.UseCases.Abstractions;
using Application.UseCases.Abstractions.Interactors;
using Application.UseCases.Payment.Interactors;
using Application.UseCases.Trade;
using Application.UseCases.Trade.Interactors;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services.AddInteractors()
            .AddUseCases();

    private static IServiceCollection AddInteractors(this IServiceCollection services)
        => services.AddScoped<ITradeCreatedInteractor, TradeCreatedInteractor>()
            .AddScoped<IPaymentCreatedInteractor, PaymentCreatedInteractor>();

    private static IServiceCollection AddUseCases(this IServiceCollection services)
        => services.AddScoped<ICreateTradeUseCase, CreateTradeUseCase>();
}