using Application.Gateways;
using Domain.Abstractions;
using Domain.Aggregates;
using Infrastructure.SqlServer.Abstractions;
using Infrastructure.SqlServer.Models;

namespace Infrastructure.SqlServer.Gateways;

public class AggregrationStoreGateway(IAggregationStoreRepository repository) : IAggregrationStoreGateway
{
    public async Task<ICollection<IEvent>> LoadEventStreamAsync(IAggregateId aggregateId,
        CancellationToken cancellationToken)
        => (await repository.GetEventsAsync(aggregateId.ToString(), cancellationToken))
            .Select(x => x.Data).ToList();

    public Task AppendAsync(IAggregateId id, IAggregateRoot aggregate, CancellationToken cancellationToken)
    {
        var events = aggregate.uncommittedEvents.Select(x => Event.Create(x.version, id, aggregate, x.@event, DateTime.UtcNow));
        return repository.AppendEvents(events, cancellationToken);
    }
}