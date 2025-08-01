using Domain.Abstractions;

namespace Domain.Aggregates;

public interface IAggregateRoot
{
    int Version { get; }
    IEnumerable<(int version, IEvent @event)> uncommittedEvents { get; }
    void Load(IEnumerable<IEvent> messages);
}