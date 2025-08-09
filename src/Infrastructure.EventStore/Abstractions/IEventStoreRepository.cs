using Infrastructure.EventStore.Models;

namespace Infrastructure.EventStore.Abstractions;

public interface IEventStoreRepository
{
    Task<ICollection<Event>> GetEventsAsync(string aggregateId, CancellationToken cancellationToken);
    Task AppendEvents(IEnumerable<Event> events, CancellationToken cancellationToken);
}