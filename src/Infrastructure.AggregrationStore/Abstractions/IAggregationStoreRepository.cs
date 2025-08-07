using Infrastructure.AggregrationStore.Models;

namespace Infrastructure.AggregrationStore.Abstractions;

public interface IAggregationStoreRepository
{
    Task<ICollection<Event>> GetEventsAsync(string aggregateId, CancellationToken cancellationToken);
    Task AppendEvents(IEnumerable<Event> events, CancellationToken cancellationToken);
}