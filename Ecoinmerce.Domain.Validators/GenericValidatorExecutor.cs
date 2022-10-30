using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Validators.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Ecoinmerce.Domain.Validators;

public class GenericValidatorExecutor : IGenericValidatorExecutor
{
    public MessageBagVO ValidatorResultIterator<TEntity>(TEntity content, AbstractValidator<TEntity> validator) where TEntity : class
    {
        ValidationResult contentResult = validator.Validate(content);
        if (!contentResult.IsValid)
        {
            MessageBagSingleEntityVO<TEntity> errors = new();
            foreach (ValidationFailure failure in contentResult.Errors)
            {
                errors.DictionaryMessages.Add(failure.PropertyName, failure.ErrorMessage);
            }
            return errors;
        }
        return new MessageBagSingleEntityVO<TEntity>("Conteúdo validado", null, false);
    }
}
