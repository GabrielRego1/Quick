using Domain.Abstractions;
using Domain.Aggregates;

namespace Application.Abstractions.Gateways;

public interface IAggregrationStoreGateway
{
    Task<ICollection<IEvent>> LoadEventStreamAsync(IAggregateId aggregateId, CancellationToken cancellationToken);
    Task AppendAsync(IAggregateId id, IAggregateRoot aggregate, CancellationToken cancellationToken);
}