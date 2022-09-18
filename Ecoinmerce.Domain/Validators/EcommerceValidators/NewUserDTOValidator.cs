using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Ecoinmerce.Domain.Validators.EcommerceValidators
{
    public class NewUserDTOValidator : AbstractValidator<NewUserDTO>
    {
        private readonly Dictionary<string, string> _requiredPatterns = new() {
                                                                             {@"[A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇ]", "Add at least one capital letter"},
                                                                             {@"[a-zàèìòùáéíóúýâêîôûãñõäëïöüÿçßØø]", "Add at least one lower letter"},
                                                                             {@"[^ \n]", "You can't use empty spaces"},
                                                                             {@"[0-9]", "Add at least one number"},
                                                                             {@"[!@#$%¨&*()^~,.?+=_|\-\\{}\[\]`´;:]", "Add at least one complex simbol, like: @!#$"}
                                                                             };
        public NewUserDTOValidator()
        {
            RuleFor(x => new { x.Name, x.Email, x.UserName, x.NakedPassword })
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .Matches(@"^[a-zA-ZàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØø ]+$").WithMessage("This name is invalid")
                .Length(3, 60).WithMessage("Your name must be between 3 and 60 chars");

            RuleFor(x => x.UserName)
                .Matches(@"^[a-zA-Z_.\-]+$").WithMessage("This user name is invalid. Use only letters and: _ - .")
                .Length(2, 40).WithMessage("Your username must be between 2 and 40 chars");

            RuleFor(x => x.Email)
                .Length(2, 50).WithMessage("Your email must be between 2 and 50 chars")
                .EmailAddress().WithMessage("You typed an invalid email");

            foreach (KeyValuePair<string, string> pattern in _requiredPatterns)
            {
                RuleFor(x => x.NakedPassword)
                    .Length(8, 40).WithMessage("Your password must be between 8 and 40 chars")
                    .Matches(pattern.Key).WithMessage(pattern.Value);
            }
        }
    }
}
