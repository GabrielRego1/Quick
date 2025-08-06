using Domain.Abstractions;
using Domain.Aggregates;

namespace Infrastructure.SqlServer.Models;

public record Event(
    long Id,
    int Version,
    string AggregateId,
    string AggregateName,
    string EventName,
    IEvent Data,
    DateTimeOffset Timestamp)
{
    public const int AggregateIdMaxLength = 100;
    public const int AggregateNameMaxLength = 100;
    public const int MessageNameMaxLength = 100;

    public static Event Create(int version, IAggregateId id, IAggregateRoot aggregate, IEvent @event,DateTimeOffset timestamp) 
        => new(0, version, id.ParseToString(), aggregate.GetType().Name, @event.GetType().Name, @event, timestamp);
}