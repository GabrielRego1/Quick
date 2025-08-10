using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Abstractions;

namespace Domain.Serialization.Converters;

public class PolymorphicIEventConverter : JsonConverter<IEvent>
{
    public override IEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var typeName = doc.RootElement.GetProperty("$type").GetString();
        var type = Type.GetType(typeName!);
        return (IEvent)doc.RootElement.Deserialize(type!, options);
    }

    public override void Write(Utf8JsonWriter writer, IEvent value, JsonSerializerOptions options)
    {
        var type = value.GetType();
        writer.WriteStartObject();
        writer.WriteString("$type", type.AssemblyQualifiedName);
        foreach (var property in type.GetProperties())
        {
            var propValue = property.GetValue(value);
            writer.WritePropertyName(property.Name);
            JsonSerializer.Serialize(writer, propValue, options);
        }

        writer.WriteEndObject();
    }
}