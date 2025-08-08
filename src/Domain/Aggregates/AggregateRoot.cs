using Domain.Abstractions;
using Domain.Extensions;

namespace Domain.Aggregates;

public abstract class AggregateRoot<TId> : IAggregateRoot<TId>
    where TId : IAggregateId, new()
{
    public TId Id { get; private set; }
    public int Version { get; private set; }
    private readonly List<(int version, IEvent @event)> _uncommittedEvents = [];
    public IEnumerable<(int version, IEvent @event)> UncommittedEvents => _uncommittedEvents;

    public void SetId(TId id) => Id = id;

    public void Load(IEnumerable<IEvent> events)
        => events.ForEach(Apply);

    protected void Raise(IEvent @event)
    {
        Apply(@event);
        Version += 1;
        _uncommittedEvents.Add((Version += 1, @event));
    }

    protected abstract void Apply(IEvent @event);
}