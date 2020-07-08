using FluentValidation;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Validators
{
    public class UserDetailsViewModelValidator : AbstractValidator<UserDetailsViewModel>
    {
        public UserDetailsViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
              .EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.PhoneNumber).MinimumLength(10).MaximumLength(15);
        }
    }
}
