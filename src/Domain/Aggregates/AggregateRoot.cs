using Domain.Abstractions;
using Domain.Extensions;

namespace Domain.Aggregates;

public abstract class AggregateRoot : IAggregateRoot
{
    public int Version { get; private set; }

    private readonly List<(int version, IMessage message)> _uncommittedMessages = [];
    public IEnumerable<(int version, IMessage message)> UncommittedMessages => _uncommittedMessages;

    public void Load(IEnumerable<IMessage> messages)
        => messages.ForEach(Apply);

    protected void Raise(IMessage message)
    {
        Apply(message);
        Version += 1;
        _uncommittedMessages.Add((Version += 1, message));
    }

    protected abstract void Apply(IMessage message);
}