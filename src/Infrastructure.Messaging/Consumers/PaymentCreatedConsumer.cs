using Application.Messages.Events;
using Application.UseCases.Abstractions.Interactors;
using MassTransit;

namespace Infrastructure.Messaging.Consumers;

internal class PaymentCreatedConsumer(IPaymentCreatedInteractor interactor) : IConsumer<PaymentCreatedEvent>
{
    public async Task Consume(ConsumeContext<PaymentCreatedEvent> context)
        => await interactor.InteractAsync(context.Message, context.CancellationToken);
}