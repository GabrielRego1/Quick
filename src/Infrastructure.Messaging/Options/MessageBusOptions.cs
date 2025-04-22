namespace Infrastructure.Messaging.Options;

public class MessageBusOptions
{
    public const string ConfigurationPath = "MessageBus";
    public required Uri ConnectionString { get; set; }
}