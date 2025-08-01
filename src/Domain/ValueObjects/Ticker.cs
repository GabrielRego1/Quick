using Domain.Exceptions;

namespace Domain.ValueObjects;

public record Ticker
{
    public string Value { get; }

    public Ticker(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Ticker cannot be empty.");

        Value = value;
    }
}