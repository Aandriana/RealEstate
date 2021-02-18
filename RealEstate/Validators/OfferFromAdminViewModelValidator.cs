using FluentValidation;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Validators
{
    public class OfferFromAdminViewModelValidator : AbstractValidator<OfferFromAgentViewModel>
    {
        public OfferFromAdminViewModelValidator()
        {
            RuleFor(o => o.Comment).MaximumLength(400);
        }
    }
}
