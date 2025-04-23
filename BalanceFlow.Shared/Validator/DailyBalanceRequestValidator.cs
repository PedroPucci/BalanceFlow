using BalanceFlow.Domain.Entity;
using BalanceFlow.Shared.Enums;
using BalanceFlow.Shared.Helpers;
using FluentValidation;

namespace BalanceFlow.Shared.Validator
{
    public class DailyBalanceRequestValidator : AbstractValidator<DailyBalanceEntity>
    {
        public DailyBalanceRequestValidator()
        {
            RuleFor(p => p.TotalCredit)
                .GreaterThan(0)
                    .WithMessage(DailyBalanceErrors.DailyBalance_Error_TotalCreditMustBeGreaterThanZero.Description());
        }
    }
}