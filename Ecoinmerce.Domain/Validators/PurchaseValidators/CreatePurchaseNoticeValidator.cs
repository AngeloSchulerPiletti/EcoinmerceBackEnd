using Ecoinmerce.Domain.Entities.Purchase;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Ecoinmerce.Domain.Validators.PurchaseValidators
{
    public class CreatePurchaseNoticeValidator : AbstractValidator<PurchaseNotice>
    {
        public CreatePurchaseNoticeValidator()
        {
        }
    }
}
