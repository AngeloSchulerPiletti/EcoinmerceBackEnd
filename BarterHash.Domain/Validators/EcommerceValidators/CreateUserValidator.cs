using BarterHash.Domain.Entities.Ecommerce;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BarterHash.Domain.Validators.EcommerceValidators
{
    public class CreateUserValidator : AbstractValidator<User>
    {
        public CreateUserValidator()
        {
            RuleFor(x => new { x.Name, x.Email, x.UserName, x.Password, x.Role })
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .Must(a => Regex.Match(a, @"/^[a-zA-ZàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØø]+$/").Success).WithMessage("This name is invalid")
                .Length(3, 60).WithMessage("Your name must be between 3 and 60 chars");

            RuleFor(x => x.UserName)
                .Must(a => Regex.Match(a, @"/^[a-zA-Z_.\-]+$/").Success).WithMessage("This user name is invalid. Use only letters and: _ - .")
                .Length(2, 40).WithMessage("Your username must be between 2 and 40 chars");

            RuleFor(x => x.Email)
                .Length(2, 50).WithMessage("Your email must be between 2 and 50 chars")
                .EmailAddress().WithMessage("You typed an invalid email");
        }
    }
}
