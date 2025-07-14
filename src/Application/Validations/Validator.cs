using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Application.Validations;

public class Validator<T>(ILogger logger)
{
    public bool Validate(T instance, IValidator<T> validator)
    {
        var validationResult = validator.Validate(instance);

        if (validationResult.IsValid)
            return true;

        validationResult.Errors.ForEach(error => logger.LogWarning("Validation error: {ErrorMessage}", error.ErrorMessage));
        return false;
    }
}