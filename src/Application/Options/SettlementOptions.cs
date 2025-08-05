namespace Application.Options;

public class SettlementOptions
{
    public const string ConfigurationPath = "Settlement";
    public required decimal MaxTradeValue { get; init; }
}