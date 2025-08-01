using Domain.Exceptions;

namespace Domain.ValueObjects;

public record Quantity
{
    public decimal Value { get; }

    public Quantity(decimal value)
    {
        if (value <= 0)
            throw new DomainException("Quantity must be greater than zero.");

        Value = value;
    }
}