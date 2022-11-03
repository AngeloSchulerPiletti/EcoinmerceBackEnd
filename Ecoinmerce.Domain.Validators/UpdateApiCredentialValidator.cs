using Ecoinmerce.Domain.Entities;
using FluentValidation;

namespace Ecoinmerce.Domain.Validators;

public class UpdateApiCredentialValidator : AbstractValidator<ApiCredential>
{
    public UpdateApiCredentialValidator()
    {
        RuleFor(x => x.AccessToken)
            .Empty().WithMessage("Não preencha esse campo");

        RuleFor(x => x.AccessTokenExpiry)
            .Empty().WithMessage("Não preencha esse campo");

        RuleFor(x => x.UpdatedAt)
            .Empty().WithMessage("Não preencha esse campo");

        RuleFor(x => x.UpdatedBy)
            .Empty().WithMessage("Não preencha esse campo");

        RuleFor(x => x.CreatedAt)
            .Empty().WithMessage("Não preencha esse campo");

        RuleFor(x => x.CreatedBy)
            .Empty().WithMessage("Não preencha esse campo");

        RuleFor(x => x.EcommerceId)
            .Empty().WithMessage("Não preencha esse campo");

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Preencha esse campo");

        RuleFor(x => x.ValidityInDays)
            .Must(x => x > 0 && x < 90).WithMessage("A credencial deve durar de 1 à 90 dias")
            .When(x => x.ValidityInDays != null);

        RuleFor(x => x.Name)
            .MaximumLength(50).WithMessage("Esse campo deve ter até 50 caracteres");

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Esse campo deve ter até 200 caracteres");

    }
}
