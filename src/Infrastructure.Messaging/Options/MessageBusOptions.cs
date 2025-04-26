namespace Infrastructure.Messaging.Options;

internal class MessageBusOptions
{
    internal const string ConfigurationPath = "MessageBus";
    internal required Uri ConnectionString { get; init; } = default!;
}