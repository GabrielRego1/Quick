using FluentValidation;

namespace Application.Validations;

public class Validator<T>(IValidator<T> validator)
{
    public bool Validate(T instance)
        => validator.Validate(instance).IsValid;
}