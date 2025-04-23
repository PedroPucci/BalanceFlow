using BalanceFlow.Infrastracture.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace BalanceFlow.Infrastracture.Repository.RepositoryUoW
{
    public interface IRepositoryUoW
    {
        ICashEntryRepository CashEntryRepository { get; }
        IDailyBalanceRepository DailyBalanceRepository { get; }

        Task SaveAsync();
        void Commit();
        IDbContextTransaction BeginTransaction();
    }
}