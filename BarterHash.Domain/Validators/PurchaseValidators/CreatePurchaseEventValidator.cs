using BarterHash.Domain.Entities.Purchase;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BarterHash.Domain.Validators.PurchaseValidators
{
    public class CreatePurchaseEventValidator : AbstractValidator<PurchaseEvent>
    {
        public CreatePurchaseEventValidator()
        {
        }
    }
}
