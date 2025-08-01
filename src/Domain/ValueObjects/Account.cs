using Domain.Exceptions;

namespace Domain.ValueObjects;

public record Account
{
    public string Value { get; }

    public Account(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Account cannot be empty.");

        Value = value;
    }
}