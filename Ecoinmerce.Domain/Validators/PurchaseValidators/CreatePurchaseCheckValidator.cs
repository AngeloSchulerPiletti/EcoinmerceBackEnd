using Ecoinmerce.Domain.Entities.Purchase;
using FluentValidation;

namespace Ecoinmerce.Domain.Validators.PurchaseValidators
{
    public class CreatePurchaseCheckValidator : AbstractValidator<PurchaseCheck>
    {
        public CreatePurchaseCheckValidator()
        {
            RuleFor(x => x.CheckOverCounter)
                .NotEmpty().WithMessage("CheckOverCounter can't be empty");
        }
    }
}
