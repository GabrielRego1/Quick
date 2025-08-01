using Domain.Abstractions;

namespace Domain.Aggregates;

public interface IAggregateRoot
{
    int Version { get; }
    IEnumerable<(int version, IMessage message)> UncommittedMessages { get; }
    void Load(IEnumerable<IMessage> messages);
}