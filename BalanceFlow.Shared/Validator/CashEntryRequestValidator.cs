using BalanceFlow.Domain.Entity;
using BalanceFlow.Shared.Enums;
using BalanceFlow.Shared.Helpers;
using FluentValidation;

namespace BalanceFlow.Shared.Validator
{
    public class CashEntryRequestValidator : AbstractValidator<CashEntryEntity>
    {
        public CashEntryRequestValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                    .WithMessage(CasyEntryErrors.CasyEntry_Error_DescriptionCanNotBeNullOrEmpty.Description())
                .MinimumLength(4)
                    .WithMessage(CasyEntryErrors.CasyEntry_Error_DescriptionLenghtLessFour.Description());
        }
    }
}