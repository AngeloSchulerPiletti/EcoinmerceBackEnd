using Ecoinmerce.Domain.Objects.VOs.Responses;
using FluentValidation;

namespace Ecoinmerce.Domain.Validators.Interfaces;

public interface IGenericValidatorExecutor
{
    public MessageBagVO ValidatorResultIterator<TEntity>(TEntity content, AbstractValidator<TEntity> validator) where TEntity : class;
}
