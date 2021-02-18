using FluentValidation;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Validators
{
    public class PropertyCreateViewModelValidator : AbstractValidator<PropertyCreateViewModel>
    {
        public PropertyCreateViewModelValidator()
        {
            RuleFor(p => p.Address).NotNull().MinimumLength(2).MaximumLength(50);
            RuleFor(p => p.City).NotNull().MinimumLength(2).MaximumLength(50);
            RuleFor(p => p.Size).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
        }
    }
}
