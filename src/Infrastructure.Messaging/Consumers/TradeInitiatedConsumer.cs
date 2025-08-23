using Application.UseCases.Trades.Interactors;
using Domain.Events;
using MassTransit;

namespace Infrastructure.Messaging.Consumers;

internal class TradeInitiatedConsumer(ITradeInitiatedInteractor interactor) : IConsumer<TradeInitiated>
{
    public async Task Consume(ConsumeContext<TradeInitiated> context)
        => await interactor.InteractAsync(context.Message, context.CancellationToken);
}