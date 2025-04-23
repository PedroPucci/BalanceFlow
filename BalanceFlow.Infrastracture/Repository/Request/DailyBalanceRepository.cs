using BalanceFlow.Domain.Entity;
using BalanceFlow.Infrastracture.Connections;
using BalanceFlow.Infrastracture.Repository.Interfaces;

namespace BalanceFlow.Infrastracture.Repository.Request
{
    public class DailyBalanceRepository : IDailyBalanceRepository
    {
        private readonly DataContext _context;

        public DailyBalanceRepository(DataContext context)
        {
            _context = context;
        }

        public Task<DailyBalanceEntity> Add(DailyBalanceEntity dailyBalanceEntity)
        {
            throw new NotImplementedException();
        }

        public DailyBalanceEntity Delete(DailyBalanceEntity dailyBalanceEntity)
        {
            throw new NotImplementedException();
        }

        public Task<List<DailyBalanceEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public DailyBalanceEntity Update(DailyBalanceEntity dailyBalanceEntity)
        {
            throw new NotImplementedException();
        }
    }
}