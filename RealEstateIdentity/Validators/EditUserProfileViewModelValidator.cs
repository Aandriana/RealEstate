using FluentValidation;
using RealEstateIdentity.ViewModels.UserViewModels;

namespace RealEstateIdentity.Validators
{
    public class EditUserProfileViewModelValidator : AbstractValidator<EditUserProfileViewModel>
    {
        public EditUserProfileViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
              .EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.PhoneNumber).MinimumLength(10).MaximumLength(15);
        }
    }
}
