using BarterHash.Domain.Entities.Ecommerce;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BarterHash.Domain.Validators.EcommerceValidators
{
    public class CreateEcommerceValidator : AbstractValidator<Ecommerce>
    {
        public CreateEcommerceValidator()
        {
            RuleFor(x => new { x.Email, x.FantasyName, x.WalletAddress, x.WebsiteDomain })
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Business email is invalid")
                .Length(3, 60).WithMessage("The business e-mail must be between 3 and 60 chars");

            RuleFor(x => x.Cnpj)
                .Must(a => Regex.Match(a, @"/^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}$/").Success).WithMessage("Invalid CNPJ") //TODO: Precisa cruiar a regex
                .Length(18).WithMessage("CNPJ must be 18 chars");

            RuleFor(x => x.WebsiteDomain)
                .Must(a => Regex.Match(a, @"/^https://[a-zA-Z0-9.\-]+$/").Success).WithMessage("Invalid website domain") //TODO: Falta a regex
                .Length(12, 200).WithMessage("The website domain must be between 12 and 200 chars");

            RuleFor(x => x.WalletAddress)
                .Must(a => Regex.Match(a, @"/^0x[a-zA-Z0-9]{40}$/").Success).WithMessage("The wallet address is invalid")
                .Length(42).WithMessage("The wallet address must be 42 chars");

        
        }
    }
}
