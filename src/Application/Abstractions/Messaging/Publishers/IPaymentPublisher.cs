using Application.Messages.Commands;

namespace Application.Abstractions.Messaging.Publishers;

public interface IPaymentPublisher
{
    Task PublishAsync(CreatePaymentCommand command, CancellationToken cancellationToken);
}