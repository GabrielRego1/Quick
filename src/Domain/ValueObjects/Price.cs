using Domain.Exceptions;

namespace Domain.ValueObjects;

public record Price
{
    public decimal Value { get; }

    public Price(decimal value)
    {
        if (value <= 0)
            throw new DomainException("Price must be greater than zero.");

        Value = value;
    }
}