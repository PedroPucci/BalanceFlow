using BalanceFlow.Application.ExtensionError;
using BalanceFlow.Domain.Entity;

namespace BalanceFlow.Application.Services.Interfaces
{
    public interface ICashEntryService
    {
        Task<Result<CashEntryEntity>> Add(CashEntryEntity cashEntryEntity);        
        Task<List<CashEntryEntity>> Get();
    }
}