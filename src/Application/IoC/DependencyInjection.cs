using Application.UseCases.Trade.Interactors;
using Application.UseCases.Trade.Interactors.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services.AddInteractors();

    private static IServiceCollection AddInteractors(this IServiceCollection services)
        => services.AddScoped<ITradeCreatedInteractor, TradeCreatedInteractor>()
            .AddScoped<IPaymentCreatedInteractor, PaymentCreatedInteractor>();
}