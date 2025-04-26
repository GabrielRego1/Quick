using Application.Messages.Events;
using Application.UseCases.Trade.Interactors.Abstractions;
using MassTransit;

namespace Infrastructure.Messaging.Consumers;

public class TradeCreatedConsumer(ITradeCreatedInteractor interactor) : IConsumer<TradeCreatedEvent>
{
    public async Task Consume(ConsumeContext<TradeCreatedEvent> context)
        => await interactor.InteractAsync(context.Message, context.CancellationToken);
}