using Domain.Abstractions;

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

    public static Event Create(int version, string aggregateId, string aggregateName, string eventName,
        IEvent data, DateTimeOffset timestamp)
        => new(0, version, aggregateId, aggregateName, eventName, data, timestamp);
}