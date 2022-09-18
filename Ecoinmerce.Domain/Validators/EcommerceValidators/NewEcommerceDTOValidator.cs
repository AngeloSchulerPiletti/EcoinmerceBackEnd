using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;
using FluentValidation;

namespace Ecoinmerce.Domain.Validators.EcommerceValidators
{
    public class NewEcommerceDTOValidator : AbstractValidator<NewEcommerceDTO>
    {
        public NewEcommerceDTOValidator()
        {
            RuleFor(x => new { x.Email, x.FantasyName, x.WalletAddress, x.WebsiteDomain })
                .NotEmpty();

            RuleFor(x => x.FantasyName)
                .Matches(@"^[a-zA-ZàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØø ]+$").WithMessage("Invalid fantasy name")
                .Length(1, 200).WithMessage("Fantasy name must have between 2 and 200 chars");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Business email is invalid")
                .Length(3, 60).WithMessage("The business e-mail must be between 3 and 60 chars");

            RuleFor(x => x.Cnpj)
                .Matches(@"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}$").WithMessage("Invalid CNPJ")
                .Length(18).WithMessage("CNPJ must be 18 chars");

            RuleFor(x => x.WebsiteDomain)
                .Matches(@"^https://[a-zA-Z0-9.\-]+$").WithMessage("Invalid website domain")
                .Length(12, 200).WithMessage("The website domain must be between 12 and 200 chars");

            RuleFor(x => x.WalletAddress)
                .Matches(@"^0x[a-zA-Z0-9]{40}$").WithMessage("The wallet address is invalid")
                .Length(42).WithMessage("The wallet address must be 42 chars");

            RuleFor(x => x.Uf)
                .Length(2).WithMessage("Invalid UF");

            RuleFor(x => x.AverageTotalEmployees)
                .Must(a => a > 0 && a < 1000000).WithMessage("Invalid average total employees");

            RuleFor(x => x.AverageAnualBiling)
                .Must(a => a > 0 && a < 10000000000000).WithMessage("Average anual biling probably wrong");
        }
    }
}
