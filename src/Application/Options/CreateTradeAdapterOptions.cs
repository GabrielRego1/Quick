namespace Application.Options;

public class CreateTradeAdapterOptions
{
    public const string ConfigurationPath = "CreateTradeAdapter";
    public required string AdapterType { get; init; }
}