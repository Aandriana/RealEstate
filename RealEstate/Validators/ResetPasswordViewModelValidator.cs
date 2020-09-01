using FluentValidation;
using RealEstate.ViewModels;
namespace RealEstate.Validators
{
    public class ResetPasswordViewModelValidator: AbstractValidator<ResetPasswordViewModel>
    {
        public ResetPasswordViewModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter the password");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Please enter the confirmation password");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Password != x.ConfirmPassword)
                {
                    context.AddFailure(nameof(x.Password), "Passwords should match");
                }
            });
        }
    }
}
