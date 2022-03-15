using BarterHash.Domain.Entities.Purchase;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BarterHash.Domain.Validators.PurchaseValidators
{
    public class CreatePurchaseNoticeValidator : AbstractValidator<PurchaseNotice>
    {
        public CreatePurchaseNoticeValidator()
        {
        }
    }
}
