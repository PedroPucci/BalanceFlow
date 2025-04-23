using BalanceFlow.Application.ExtensionError;
using BalanceFlow.Domain.Entity;

namespace BalanceFlow.Application.Services.Interfaces
{
    public interface ICashEntryService
    {
        Task<Result<CashEntryEntity>> Add(CashEntryEntity cashEntryEntity);
        Task<Result<CashEntryEntity>> Update(CashEntryEntity cashEntryEntity);
        Task Delete(int cashEntryId);
        Task<List<CashEntryEntity>> Get();
    }
}