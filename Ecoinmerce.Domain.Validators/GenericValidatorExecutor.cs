using Ecoinmerce.Domain.Objects.VOs.Responses;
using FluentValidation;
using FluentValidation.Results;

namespace Ecoinmerce.Domain.Validators;

public static class GenericValidatorExecutor
{
    public static MessageBagVO ValidatorResultIterator<TEntity>(TEntity content, AbstractValidator<TEntity> validator, string baseIdentifier = null) where TEntity : class
    {
        ValidationResult contentResult = validator.Validate(content);
        if (!contentResult.IsValid)
        {
            MessageBagSingleEntityVO<TEntity> errors = new();
            Dictionary<string, object> errorsDictionary = new();

            foreach (ValidationFailure failure in contentResult.Errors)
            {
                string propertyNameFormatted = char.ToLower(failure.PropertyName[0]) + failure.PropertyName.Substring(1);
                if (!errorsDictionary.Any(x => x.Key == propertyNameFormatted))
                    errorsDictionary.Add(propertyNameFormatted, new List<string>());

                ((List<string>)errorsDictionary[propertyNameFormatted]).Add(failure.ErrorMessage);
            }

            if (baseIdentifier == null) errors.DictionaryMessages = errorsDictionary;
            else errors.DictionaryMessages.Add(baseIdentifier, errorsDictionary);

            return errors;
        }
        return new MessageBagSingleEntityVO<TEntity>("Conteúdo validado", null, false);
    }
}
