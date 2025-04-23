using BalanceFlow.Domain.Entity;
using BalanceFlow.Infrastracture.Connections;
using BalanceFlow.Infrastracture.Repository.Interfaces;

namespace BalanceFlow.Infrastracture.Repository.Request
{
    public class CashEntryRepository : ICashEntryRepository
    {
        private readonly DataContext _context;

        public CashEntryRepository(DataContext context)
        {
            _context = context;
        }

        public Task<CashEntryEntity> Add(CashEntryEntity cashEntryEntity)
        {
            throw new NotImplementedException();
        }

        public CashEntryEntity Delete(CashEntryEntity cashEntryEntity)
        {
            throw new NotImplementedException();
        }

        public Task<List<CashEntryEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public CashEntryEntity Update(CashEntryEntity cashEntryEntity)
        {
            throw new NotImplementedException();
        }
    }
}