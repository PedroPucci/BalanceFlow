using BalanceFlow.Domain.Entity;

namespace BalanceFlow.Infrastracture.Repository.Interfaces
{
    public interface ICashEntryRepository
    {
        Task<CashEntryEntity> Add(CashEntryEntity cashEntryEntity);
        Task<List<CashEntryEntity>> Get();
    }
}