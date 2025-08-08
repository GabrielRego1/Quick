using Application.Abstractions.Gateways;
using Domain.Abstractions;
using Domain.Aggregates;
using Infrastructure.AggregrationStore.Abstractions;
using Infrastructure.AggregrationStore.Models;

namespace Infrastructure.AggregrationStore.Gateways;

public class AggregrationStoreGateway(IAggregationStoreRepository repository) : IAggregrationStoreGateway
{
    public async Task<ICollection<IEvent>> LoadEventStreamAsync(IAggregateId aggregateId,
        CancellationToken cancellationToken)
        => (await repository.GetEventsAsync(aggregateId.ToString(), cancellationToken))
            .Select(x => x.Data).ToList();

    public Task AppendAsync(IAggregateId id, IAggregateRoot aggregate, CancellationToken cancellationToken)
    {
        var events = aggregate.UncommittedEvents.Select(x => Event.Create(x.version, id, aggregate, x.@event, DateTime.UtcNow));
        return repository.AppendEvents(events, cancellationToken);
    }
}