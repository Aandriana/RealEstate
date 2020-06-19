using FluentValidation;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Validators
{
    public class AgentRegisterViewModelValidator: AbstractValidator<AgentRegisterViewModel>
    {
        public AgentRegisterViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
              .EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter the password");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Please enter the confirmation password");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Password != x.ConfirmPassword)
                {
                    context.AddFailure(nameof(x.Password), "Passwords should match");
                }
            });
            RuleFor(x => x.PhoneNumber).MinimumLength(10).MaximumLength(15);
        }
    }
}
