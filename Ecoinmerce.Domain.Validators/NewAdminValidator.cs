using Ecoinmerce.Domain.Entities;
using FluentValidation;

namespace Ecoinmerce.Domain.Validators;

public class NewAdminValidator : AbstractValidator<EcommerceAdmin>
{
    private readonly Dictionary<string, string> _passwordPatterns = new()
    {
        { @"[A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇ]", "Senha precisa ter pelo menos uma letra maiúscula" },
        { @"[a-zàèìòùáéíóúýâêîôûãñõäëïöüÿçßØø]", "Senha precisa ter pelo menos uma letra minúscula" },
        { @"[^ \n]", "Não use espaços em branco" },
        { @"[0-9]", "Adicione pelo menos um número" },
        { @"[!@#$%¨&*()^~,.?+=_|\-\\{}\[\]`´;:]", "Adicione pelo menos um símbolo, por exemplo: @,!#$" }
    };

    public NewAdminValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Preencha o email")
            .MaximumLength(60).WithMessage("Até 128 caracteres")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.GetNakedPassword())
                .NotEmpty().WithMessage("Preencha a senha")
                .Length(8, 40).WithMessage("Sua senha precisa ter 8 a 40 caracteres");

        foreach (KeyValuePair<string, string> pattern in _passwordPatterns)
        {
            RuleFor(x => x.GetNakedPassword())
                .Matches(pattern.Key).WithMessage(pattern.Value);
        }

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Preencha seu primeiro nome")
            .MaximumLength(20).WithMessage("Até 20 caracteres")
            .Matches(@"^[a-zA-ZàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇ ]+$").WithMessage("Primeiro nome inválido");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Preencha seu último nome")
            .MaximumLength(40).WithMessage("Até 40 caracteres")
            .Matches(@"^[a-zA-ZàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇ ]+$").WithMessage("Último nome inválido");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Preencha seu username")
            .MaximumLength(30).WithMessage("Até 30 caracteres")
            .Matches(@"^[a-zA-Z_\-]+$").WithMessage("Utilize apenas letras, \"-\" e \"_\"");

        RuleFor(x => x.EcommerceId)
            .Empty().WithMessage("Não preencha esse campo!");

        RuleFor(x => x.IsDeleted)
            .Empty().WithMessage("Não preencha esse campo!");

        RuleFor(x => x.IsEmailConfirmed)
            .Empty().WithMessage("Não preencha esse campo!");

        RuleFor(x => x.Id)
            .Empty().WithMessage("Não preencha esse campo!");
    }
}
