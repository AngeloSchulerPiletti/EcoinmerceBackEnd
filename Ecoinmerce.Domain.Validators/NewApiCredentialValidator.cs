using Ecoinmerce.Domain.Entities;
using FluentValidation;

namespace Ecoinmerce.Domain.Validators;

public class NewApiCredentialValidator : AbstractValidator<ApiCredential>
{
    public NewApiCredentialValidator()
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
            .Empty().WithMessage("Não preencha esse campo");

        RuleFor(x => x.ValidityInDays)
            .NotEmpty().WithMessage("Preencha esse campo")
            .DependentRules(() =>
            {
                RuleFor(x => x.ValidityInDays)
                    .Must(x => x > 0 && x < 90).WithMessage("A credencial deve durar de 1 à 90 dias");
            });

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Preencha esse campo")
            .MaximumLength(50).WithMessage("Até 50 caracteres");

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Até 200 caracteres");

    }
}
