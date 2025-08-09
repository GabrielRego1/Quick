using Application.Abstractions.Gateways;
using Domain.Abstractions;
using Domain.Aggregates;
using Infrastructure.EventStore.Abstractions;
using Infrastructure.EventStore.Models;

namespace Infrastructure.EventStore.Gateways;

public class EventStoreGateway(IEventStoreRepository repository) : IEventStoreGateway
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