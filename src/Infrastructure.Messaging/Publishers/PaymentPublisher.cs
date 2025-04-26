using Application.Abstractions.Messaging;
using Application.Abstractions.Messaging.Publishers;
using Application.Messages.Commands;

namespace Infrastructure.Messaging.Publishers;

public class PaymentPublisher(IMessageBusProducer producer) : IPaymentPublisher
{
    public Task PublishAsync(CreatePaymentCommand command, CancellationToken cancellationToken)
        => producer.Publish(command, cancellationToken);
}