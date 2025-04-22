using Domain.Entities;

namespace Application.Abstractions.Messaging.Publishers;

public interface ITradePublisher
{
    //ToDo: Change TYPE Trade to Command
    Task PublishAsync(Trade trade, CancellationToken cancellationToken);
}