using Application.Messages.Events;
using Application.UseCases.Trade.Interactors.Abstractions;
using MassTransit;

namespace Infrastructure.Messaging.Consumers;

public class PaymentCreatedConsumer(IPaymentCreatedInteractor interactor) : IConsumer<PaymentCreatedEvent>
{
    public async Task Consume(ConsumeContext<PaymentCreatedEvent> context)
        => await interactor.InteractAsync(context.Message, context.CancellationToken);
}