using System.Text.Json;
using Domain.Abstractions;
using Domain.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EventStore.Converters;

public class EventConverter() : ValueConverter<IEvent, string>(
    v => JsonSerializer.Serialize(v, SerializationDefinitions.Default),
    v => JsonSerializer.Deserialize<IEvent>(v, SerializationDefinitions.Default)!);