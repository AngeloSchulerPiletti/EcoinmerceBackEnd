using BarterHash.Domain.Entities.Purchase;
using FluentValidation;

namespace BarterHash.Domain.Validators.PurchaseValidators
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
