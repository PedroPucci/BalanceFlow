using BalanceFlow.Application.ExtensionError;
using BalanceFlow.Domain.Entity;

namespace BalanceFlow.Application.Services.Interfaces
{
    public interface IDailyBalanceService
    {
        Task<Result<DailyBalanceEntity>> Add(DailyBalanceEntity dailyBalanceEntity);
        Task<Result<DailyBalanceEntity>> Update(DailyBalanceEntity dailyBalanceEntity);
        Task Delete(int dailyBalanceId);
        Task<List<DailyBalanceEntity>> Get();
    }
}