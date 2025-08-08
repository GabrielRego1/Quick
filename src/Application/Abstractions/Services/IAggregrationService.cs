using Domain.Aggregates;

namespace Application.Abstractions.Services;

public interface IAggregrationService
{
    Task<TAggregate> LoadAggregateAsync<TAggregate, TId>(TId id, CancellationToken cancellationToken)
        where TAggregate : IAggregateRoot<TId>, new()
        where TId : IAggregateId, new();


    Task AppendEventAsync(IAggregateId id, IAggregateRoot aggregate, CancellationToken cancellationToken);
}