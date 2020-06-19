using FluentValidation;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Validators
{
    public class OfferFromUserViewModelValidatir: AbstractValidator<OfferFromUserViewModel>
    {
        public OfferFromUserViewModelValidatir()
        {
            RuleFor(o => o.Comment).MaximumLength(200);
        }
    }
}
