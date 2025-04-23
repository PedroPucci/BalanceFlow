using BalanceFlow.Domain.Entity;
using BalanceFlow.Infrastracture.Connections;
using BalanceFlow.Infrastracture.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BalanceFlow.Infrastracture.Repository.Request
{
    public class DailyBalanceRepository : IDailyBalanceRepository
    {
        private readonly DataContext _context;

        public DailyBalanceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<DailyBalanceEntity> Add(DailyBalanceEntity dailyBalanceEntity)
        {
            if (dailyBalanceEntity is null)
                throw new ArgumentNullException(nameof(dailyBalanceEntity), "Daily balance cannot be null");

            var result = await _context.DailyBalanceEntity.AddAsync(dailyBalanceEntity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<DailyBalanceEntity>> Get()
        {
            return await _context.DailyBalanceEntity
                .AsNoTracking()
                .OrderBy(balance => balance.Id)
                .Select(balance => new DailyBalanceEntity
                {
                    Id = balance.Id,
                    FinalBalance = balance.FinalBalance,
                    TotalDebit = balance.TotalDebit,
                })
                .ToListAsync();
        }
    }
}