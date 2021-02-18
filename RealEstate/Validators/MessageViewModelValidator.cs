using FluentValidation;
using RealEstate.ViewModels;

namespace RealEstate.Validators
{
    public class MessageViewModelValidator: AbstractValidator<AddMessageViewModel>
    {
        public MessageViewModelValidator()
        {
            RuleFor(m => m.Text).MaximumLength(1500);
        }
    }
}
