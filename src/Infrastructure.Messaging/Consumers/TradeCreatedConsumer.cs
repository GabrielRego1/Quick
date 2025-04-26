using Application.Messages.Events;
using Application.UseCases.Abstractions.Interactors;
using MassTransit;

namespace Infrastructure.Messaging.Consumers;

internal class TradeCreatedConsumer(ITradeCreatedInteractor interactor) : IConsumer<TradeCreatedEvent>
{
    public async Task Consume(ConsumeContext<TradeCreatedEvent> context)
        => await interactor.InteractAsync(context.Message, context.CancellationToken);
}