using CardActionService.DTO;
using FluentValidation;

namespace CardActionService.Validators
{
    public class GetCardActionsRequestValidator : AbstractValidator<GetCardActionsRequest>
    {
        public GetCardActionsRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("EST: My FluentValidation is working!");
            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Card Number is required!!.");
        }
    }
}
