using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.Serialization;

public static class SerializationDefinitions
{
    public static JsonSerializerOptions Default { get; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}