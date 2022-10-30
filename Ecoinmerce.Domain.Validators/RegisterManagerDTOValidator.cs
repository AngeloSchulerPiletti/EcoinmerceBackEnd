using Ecoinmerce.Domain.Objects.DTOs;
using FluentValidation;

namespace Ecoinmerce.Domain.Validators;

public class RegisterManagerDTOValidator : AbstractValidator<RegisterManagerDTO>
{
    private readonly Dictionary<string, string> _passwordPatterns = new()
    {
        { @"[A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇ]", "Senha precisa ter pelo menos uma letra maiúscula" },
        { @"[a-zàèìòùáéíóúýâêîôûãñõäëïöüÿçßØø]", "Senha precisa ter pelo menos uma letra minúscula" },
        { @"[^ \n]", "Não use espaços em branco" },
        { @"[0-9]", "Adicione pelo menos um número" },
        { @"[!@#$%¨&*()^~,.?+=_|\-\\{}\[\]`´;:]", "Adicione pelo menos um símbolo, por exemplo: @,!#$" }
    };

    public RegisterManagerDTOValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Preencha o email")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.NakedPassword)
                .NotEmpty().WithMessage("Preencha a senha")
                .Length(8, 40).WithMessage("Sua senha precisa ter 8 a 40 caracteres");

        foreach (KeyValuePair<string, string> pattern in _passwordPatterns)
        {
            RuleFor(x => x.NakedPassword)
                .Matches(pattern.Key).WithMessage(pattern.Value);
        }

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Preencha seu primeiro nome")
            .Matches(@"^[a-zA-ZàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇ ]+$").WithMessage("Primeiro nome inválido");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Preencha seu último nome")
            .Matches(@"^[a-zA-ZàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇ ]+$").WithMessage("Último nome inválido");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Preencha seu username")
            .Matches(@"^[a-zA-Z_\-]+$").WithMessage("Utilize apenas letras, \"-\" e \"_\"");

        RuleFor(x => x.Cellphone)
            .NotEmpty().WithMessage("Adicione seu celular")
            .Matches(@"^[0-9]{2}9[0-9]{8}$").WithMessage("Celular inválido");

        RuleFor(x => x.Phone)
            .Matches(@"^[0-9]{10}$").WithMessage("Telefone inválido")
            .When(x => x.Phone != null);

        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage("Preencha o CPF")
            .Matches(@"^[0-9]{11}$").WithMessage("CPF inválido")
            .Must(x => IsCpfValid(x));
    }

    public static bool IsCpfValid(string cpf)
    {
        int starter = 2;
        int result = 0;
        for (int i = starter; i <= 10; i++)
        {
            result += CharToInt(cpf[10 - i]) * i;
        }
        result = (result * 10) % 11;
        if (result == 10 || result == 11) result = 0;

        if (result != CharToInt(cpf[9]))
            return false;

        result = 0;
        for (int i = starter; i <= 11; i++)
        {
            result += CharToInt(cpf[11 - i]) * i;
        }
        result = (result * 10) % 11;
        if (result == 10 || result == 11) result = 0;

        return result == CharToInt(cpf[10]);
    }

    private static int CharToInt(char c)
    {
        return (int)char.GetNumericValue(c);
    }
}
