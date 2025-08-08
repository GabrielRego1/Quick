using Application.Abstractions.Gateways;
using Application.Abstractions.Services;
using Domain.Aggregates;

namespace Application.Services;

public class AggregrationService(
    IAggregrationStoreGateway aggregrationStoreGateway,
    IMessageBusGateway messageBusGateway) : IAggregrationService
{
    public async Task<TAggregate> LoadAggregateAsync<TAggregate, TId>(TId id, CancellationToken cancellationToken)
        where TAggregate : IAggregateRoot<TId>, new()
        where TId : IAggregateId, new()
    {
        var aggregate = new TAggregate();
        var eventStream = await aggregrationStoreGateway.LoadEventStreamAsync(id, cancellationToken);
        aggregate.Load(eventStream);
        return aggregate;
    }

    public async Task AppendEventAsync(IAggregateId id, IAggregateRoot aggregate, CancellationToken cancellationToken)
    {
        await aggregrationStoreGateway.AppendAsync(id, aggregate, cancellationToken);
        await messageBusGateway.PublishAsync(aggregate, cancellationToken);
    }
}