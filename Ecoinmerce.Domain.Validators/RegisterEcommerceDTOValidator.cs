using Ecoinmerce.Domain.Objects.DTOs;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Infra.ViaCep;
using FluentValidation;

namespace Ecoinmerce.Domain.Validators;

public class RegisterEcommerceDTOValidator : AbstractValidator<RegisterEcommerceDTO>
{
    public RegisterEcommerceDTOValidator()
    {
        RuleFor(x => x.Cep)
            .NotEmpty().WithMessage("Preencha o CEP")
            .Length(8).WithMessage("CEP inválido")
            .Must(x => IsCep(x)).WithMessage("CEP inválido");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Adicione seu telefone")
            .Matches(@"^[0-9]{10}$").WithMessage("Telefone inválido");

        RuleFor(x => x.SocialReason)
            .NotEmpty().WithMessage("Preencha a razão social");

        RuleFor(x => x.Website)
            .NotEmpty().WithMessage("Preencha o website")
            .Matches(@"^http[s]{0,1}://[a-zA-Z0-9_\-]+\.[a-zA-Z0-9_\-\.]+$").WithMessage("Website inválido");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Preencha o email")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.AverageAnnualBilling)
            .NotEmpty().WithMessage("Preencha o faturamento anual");

        RuleFor(x => x.AverageTotalEmployees)
            .NotEmpty().WithMessage("Preencha o número de funcionários");

        RuleFor(x => x.Cnpj)
            .NotEmpty().WithMessage("Preencha o CNPJ")
            .Must(x => IsCnpj(x)).WithMessage("CNPJ inválido");

        RuleFor(x => x.FantasyName)
            .NotEmpty().WithMessage("Preencha o nome fantasia");

        RuleFor(x => x.WalletAddress)
            .Matches(@"^0x[A-Za-z0-9]{40}$").WithMessage("Endereço de wallet inválido")
            .When(x => x.WalletAddress != null);

        RuleFor(x => x.WalletName)
            .NotEmpty().WithMessage("Dê um nome para a sua wallet")
            .MaximumLength(20).WithMessage("O nome da wallet não pode ter mais de 20 caracteres")
            .Matches(@"^[A-Za-z0-9 ]+$").WithMessage("Endereço de wallet inválido");
    }

    public static bool IsCep(string cep)
    {
        (ViaCepResponseVO response, bool serverOut) = ViaCepService.GetCompleteAddress(cep);
        return response != null || serverOut;
    }

    public static bool IsCnpj(string cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;
        if (cnpj.Length != 14)
            return false;
        tempCnpj = cnpj.Substring(0, 12);
        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCnpj += digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito += resto.ToString();
        return cnpj.EndsWith(digito);
    }
}
