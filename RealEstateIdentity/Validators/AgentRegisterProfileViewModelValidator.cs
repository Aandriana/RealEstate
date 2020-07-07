using FluentValidation;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Validators
{
    public class AgentRegisterProfileViewModelValidator : AbstractValidator<AgentRegisterProfileViewModel>
    {
        public AgentRegisterProfileViewModelValidator()
        {
            RuleFor(a => a.Description).MaximumLength(300);
            RuleFor(a => a.City).MaximumLength(1).MaximumLength(30);
            RuleFor(a => a.DefaultRate).NotEmpty();
        }
    }
}
