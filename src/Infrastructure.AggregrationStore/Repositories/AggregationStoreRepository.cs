using Infrastructure.AggregrationStore.Abstractions;
using Infrastructure.AggregrationStore.Contexts;
using Infrastructure.AggregrationStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AggregrationStore.Repositories;

public class AggregationStoreRepository(EventStoreDbContext dbContext) : IAggregationStoreRepository
{
    public async Task<ICollection<Event>> GetEventsAsync(string aggregateId, CancellationToken cancellationToken)
        => await dbContext.Events
            .Where(x => x.AggregateId == aggregateId)
            .ToListAsync(cancellationToken);


    public Task AppendEvents(IEnumerable<Event> events, CancellationToken cancellationToken)
    {
        dbContext.Events.AddRangeAsync(events, cancellationToken);
        dbContext.SaveChangesAsync(cancellationToken);
        return Task.CompletedTask;
    }
}