using BalanceFlow.Application.Services;

namespace BalanceFlow.Application.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        CashEntryService CashEntryService { get; }
        DailyBalanceService DailyBalanceService { get; }
    }
}