using Application.Messages.Commands;

namespace Application.Abstractions.Messaging.Publishers;

public interface ITradePublisher
{
    Task PublishAsync(CreateTradeCommand command, CancellationToken cancellationToken);
}