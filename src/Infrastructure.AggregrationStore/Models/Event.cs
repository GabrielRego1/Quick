using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstractions;
using Domain.Aggregates;

namespace Infrastructure.AggregrationStore.Models;

public record Event
{
    public long Id { get; private set; }
    public int Version { get; private set; }
    public string AggregateId { get; private set; }
    public string AggregateName { get; private set; }
    public string EventName { get; private set; }
    public IEvent Data { get; private set; }
    public DateTimeOffset Timestamp { get; private set; }

    private Event()
    {
    }

    public const int AggregateIdMaxLength = 100;
    public const int AggregateNameMaxLength = 100;
    public const int MessageNameMaxLength = 100;

    public static Event Create(int version, IAggregateId id, IAggregateRoot aggregate, IEvent @event,
        DateTimeOffset timestamp)
        => new()
        {
            Id = 0,
            Version = version,
            AggregateId = id.ParseToString(),
            AggregateName = aggregate.GetType().Name,
            EventName = @event.GetType().Name,
            Data = @event,
            Timestamp = timestamp,
        };
}