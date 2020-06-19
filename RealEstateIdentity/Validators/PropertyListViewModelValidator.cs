using FluentValidation;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Validators
{
    public class PropertyListViewModelValidator : AbstractValidator<PropertyListViewModel>
    {
        public PropertyListViewModelValidator()
        {
            RuleFor(p => p.Address).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(p => p.City).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(p => p.Size).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
        }
    }
}
