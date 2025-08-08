using FluentValidation;

namespace Application.Validations;

public class Validator<T>
{
    public bool Validate(T instance, IValidator<T> validator)
        => validator.Validate(instance).IsValid;
}