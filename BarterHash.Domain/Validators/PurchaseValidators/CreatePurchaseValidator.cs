using BarterHash.Domain.Entities.Purchase;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BarterHash.Domain.Validators.PurchaseValidators
{
    public class CreatePurchaseValidator : AbstractValidator<Purchase>
    {
        public CreatePurchaseValidator()
        {
            RuleFor(x => x.EcommerceWalletAddress)
                .NotEmpty().WithMessage("EcommerceWalletAddress can't be empty")
                .Must(address => Regex.IsMatch(address, @"^0x[\w]{40}$")).WithMessage("Invalid EcommerceWalletAddress");

            RuleFor(x => x.CostumerWalletAddress)
                .NotEmpty().WithMessage("CostumerWalletAddress can't be empty")
                .Must(address => Regex.IsMatch(address, @"^0x[\w]{40}$")).WithMessage("Invalid CostumerWalletAddress");

            RuleFor(x => x.PurchaseIdentifier)
                .NotEmpty().WithMessage("PurchaseIdentifier can't be empty")
                .Must(identifier => Regex.IsMatch(identifier, @"^[a-zA-Z0-9_\-.]$")).WithMessage("Invalid PurchaseIdentifier. Use only letters, numbers, and \"_ - .\"");

            RuleFor(x => x.PurchaseNotice).NotNull().When(x => x.PurchaseEvent == null).WithMessage("PurchaseNotice can't be null when PurchaseEvent is null");
            RuleFor(x => x.PurchaseNotice).NotNull().When(x => x.PurchaseEventId == null).WithMessage("PurchaseNotice can't be null when PurchaseEventId is null");
            RuleFor(x => x.PurchaseNoticeId).NotNull().When(x => x.PurchaseEventId == null).WithMessage("PurchaseNoticeId can't be null when PurchaseEventId is null");
            RuleFor(x => x.PurchaseNotice).NotNull().When(x => x.PurchaseNoticeId != null).WithMessage("PurchaseNotice can't be null when PurchaseNoticeId is null");
            RuleFor(x => x.PurchaseNoticeId).NotNull().When(x => x.PurchaseNotice != null).WithMessage("PurchaseNoticeId can't be null when PurchaseNotice is null");

            RuleFor(x => x.PurchaseEvent).NotNull().When(x => x.PurchaseNotice == null).WithMessage("PurchaseEvent can't be null when PurchaseEvent is null");
            RuleFor(x => x.PurchaseEvent).NotNull().When(x => x.PurchaseNoticeId == null).WithMessage("PurchaseEvent can't be null when PurchaseNoticeId is null");
            RuleFor(x => x.PurchaseEventId).NotNull().When(x => x.PurchaseNoticeId == null).WithMessage("PurchaseEventId can't be null when PurchaseNoticeId is null");
            RuleFor(x => x.PurchaseEvent).NotNull().When(x => x.PurchaseEventId != null).WithMessage("PurchaseEvent can't be null when PurchaseEventId is null");
            RuleFor(x => x.PurchaseEventId).NotNull().When(x => x.PurchaseEvent != null).WithMessage("PurchaseEventId can't be null when PurchaseEvent is null");

            RuleFor(x => x.PurchaseCheck).NotNull().WithMessage("PurchaseCheck can't be null, but doesn't need initial counter");
        }
    }
}
