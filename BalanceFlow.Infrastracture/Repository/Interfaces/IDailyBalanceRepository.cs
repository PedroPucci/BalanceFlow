using BalanceFlow.Domain.Entity;

namespace BalanceFlow.Infrastracture.Repository.Interfaces
{
    public interface IDailyBalanceRepository
    {
        Task<DailyBalanceEntity> Add(DailyBalanceEntity dailyBalanceEntity);
        DailyBalanceEntity Update(DailyBalanceEntity dailyBalanceEntity);
        DailyBalanceEntity Delete(DailyBalanceEntity dailyBalanceEntity);
        Task<List<DailyBalanceEntity>> Get();
    }
}