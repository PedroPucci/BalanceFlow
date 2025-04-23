using BalanceFlow.Application.ExtensionError;
using BalanceFlow.Application.Services.Interfaces;
using BalanceFlow.Domain.Entity;
using BalanceFlow.Infrastracture.Repository.RepositoryUoW;

namespace BalanceFlow.Application.Services
{
    public class DailyBalanceService : IDailyBalanceService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public DailyBalanceService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Result<DailyBalanceEntity>> Add(DailyBalanceEntity dailyBalanceEntity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int dailyBalanceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DailyBalanceEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Result<DailyBalanceEntity>> Update(DailyBalanceEntity dailyBalanceEntity)
        {
            throw new NotImplementedException();
        }
    }
}