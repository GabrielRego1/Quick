using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Serialization.Converters;

namespace Domain.Serialization;

public static class SerializationDefinitions
{
    public static JsonSerializerOptions Default
    {
        get
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            options.Converters.Add(new PolymorphicIEventConverter());
            return options;
        }
    }
}