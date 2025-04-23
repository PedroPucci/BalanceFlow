using BalanceFlow.Infrastracture.Connections;
using BalanceFlow.Infrastracture.Repository.Interfaces;
using BalanceFlow.Infrastracture.Repository.Request;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace BalanceFlow.Infrastracture.Repository.RepositoryUoW
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private readonly DataContext _context;
        private bool _disposed = false;
        private ICashEntryRepository? _cashEntryRepository = null;
        private IDailyBalanceRepository? _dailyBalanceRepository = null;

        public RepositoryUoW(DataContext context)
        {
            _context = context;
        }

        public ICashEntryRepository CashEntryRepository
        {
            get
            {
                if (_cashEntryRepository is null)
                {
                    _cashEntryRepository = new CashEntryRepository(_context);
                }
                return _cashEntryRepository;
            }
        }

        public IDailyBalanceRepository DailyBalanceRepository
        {
            get
            {
                if (_dailyBalanceRepository is null)
                {
                    _dailyBalanceRepository = new DailyBalanceRepository(_context);
                }
                return _dailyBalanceRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error($"Database connection failed: {ex.Message}");
                throw new ApplicationException("Database is not available. Please check the connection.");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}