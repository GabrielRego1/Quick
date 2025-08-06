namespace Infrastructure.SqlServer.Options;

public class EventStoreOptions
{
    public const string ConfigurationPath = "EventStore";
    public required string ConnectionString { get; set; } = null!;
}