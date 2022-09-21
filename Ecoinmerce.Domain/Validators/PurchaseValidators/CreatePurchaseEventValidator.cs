using Ecoinmerce.Domain.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Ecoinmerce.Domain.Validators.PurchaseValidators
{
    public class CreatePurchaseEventValidator : AbstractValidator<PurchaseEvent>
    {
        public CreatePurchaseEventValidator()
        {
        }
    }
}
