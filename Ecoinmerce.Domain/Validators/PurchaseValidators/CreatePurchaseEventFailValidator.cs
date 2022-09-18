using Ecoinmerce.Domain.Entities.Purchase;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Ecoinmerce.Domain.Validators.PurchaseValidators
{
    public class CreatePurchaseEventFailValidator : AbstractValidator<PurchaseEventFail>
    {
        public CreatePurchaseEventFailValidator()
        {
            RuleFor(x => x.LogAddress)
                .NotEmpty().WithMessage("LogAddress can't be empty")
                .Must(address => Regex.IsMatch(address, @"^0x[\w]{40}$")).WithMessage("Invalid EcommerceWalletAddress");
        }
    }
}
