using FluentValidation;
using RealEstateIdentity.ViewModels.UserViewModels;

namespace RealEstateIdentity.Validators
{
    public class EditAgentProfileViewModelValidator : AbstractValidator<EditAgentProfileViewModel>
    {
        public EditAgentProfileViewModelValidator()
        {
            RuleFor(a => a.Description).MaximumLength(300);
            RuleFor(a => a.City).MaximumLength(1).MaximumLength(30);
            RuleFor(a => a.DefaultRate).NotEmpty();
        }
    }
}
