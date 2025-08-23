using Infrastructure.EventStore.Abstractions;
using Infrastructure.EventStore.Contexts;
using Infrastructure.EventStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EventStore.Repositories;

public class EventStoreRepository(EventStoreDbContext dbContext) : IEventStoreRepository
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