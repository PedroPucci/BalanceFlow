using BalanceFlow.Application.ExtensionError;
using BalanceFlow.Application.Services.Interfaces;
using BalanceFlow.Domain.Entity;
using BalanceFlow.Infrastracture.Repository.RepositoryUoW;

namespace BalanceFlow.Application.Services
{
    public class CashEntryService : ICashEntryService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public CashEntryService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Result<CashEntryEntity>> Add(CashEntryEntity cashEntryEntity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int cashEntryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CashEntryEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Result<CashEntryEntity>> Update(CashEntryEntity cashEntryEntity)
        {
            throw new NotImplementedException();
        }
    }
}