namespace Infrastructure.Messaging.Options;

public class MessageBusOptions
{
    public const string ConfigurationPath = "MessageBusOptions";
    public required Uri ConnectionString { get; set; }
}