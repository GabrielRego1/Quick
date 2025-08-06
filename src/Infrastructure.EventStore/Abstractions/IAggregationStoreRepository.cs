using Infrastructure.SqlServer.Models;

namespace Infrastructure.SqlServer.Abstractions;

public interface IAggregationStoreRepository
{
    Task<ICollection<Event>> GetEventsAsync(string aggregateId, CancellationToken cancellationToken);
    Task AppendEvents(IEnumerable<Event> events, CancellationToken cancellationToken);
}