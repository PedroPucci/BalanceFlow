using BalanceFlow.Domain.Entity;

namespace BalanceFlow.Infrastracture.Repository.Interfaces
{
    public interface IDailyBalanceRepository
    {
        Task<DailyBalanceEntity> Add(DailyBalanceEntity dailyBalanceEntity);
        Task<List<DailyBalanceEntity>> Get();
    }
}