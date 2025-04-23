using System.ComponentModel;

namespace BalanceFlow.Shared.Enums
{
    public enum DailyBalanceErrors
    {
        [Description("'TotalCredit' must be greater than zero.")]
        DailyBalance_Error_TotalCreditMustBeGreaterThanZero,
    }
}