using Infrastructure.SqlServer.Abstractions;
using Infrastructure.SqlServer.Contexts;
using Infrastructure.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories;

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