using BalanceFlow.Domain.Entity;
using BalanceFlow.Infrastracture.Connections;
using BalanceFlow.Infrastracture.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BalanceFlow.Infrastracture.Repository.Request
{
    public class CashEntryRepository : ICashEntryRepository
    {
        private readonly DataContext _context;

        public CashEntryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CashEntryEntity> Add(CashEntryEntity cashEntryEntity)
        {
            if (cashEntryEntity is null)
                throw new ArgumentNullException(nameof(cashEntryEntity), "CashEntry cannot be null");

            var result = await _context.CashEntryEntity.AddAsync(cashEntryEntity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<CashEntryEntity>> Get()
        {
            return await _context.CashEntryEntity
                .AsNoTracking()
                .OrderBy(entry => entry.Id)
                .Select(entry => new CashEntryEntity
                {
                    Id = entry.Id,
                    Amount = entry.Amount,
                    CreatedAt = entry.CreatedAt,
                    Description = entry.Description,
                    TransactionDate = entry.TransactionDate,
                })
                .ToListAsync();
        }
    }
}