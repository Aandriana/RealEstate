using FluentValidation;
using RealEstate.ViewModels;

namespace RealEstate.Validators
{
    public class ChatViewModelValidator : AbstractValidator<AddChatViewModel>
    {
        public ChatViewModelValidator()
        {
            RuleFor(c => c.Name).MaximumLength(50);
        }
    }
}
