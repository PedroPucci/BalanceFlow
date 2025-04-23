using BalanceFlow.Application.Services;
using BalanceFlow.Infrastracture.Repository.RepositoryUoW;

namespace BalanceFlow.Application.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        private CashEntryService cashEntryService;
        private DailyBalanceService dailyBalanceService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public CashEntryService CashEntryService
        {
            get
            {
                if (cashEntryService is null)
                    cashEntryService = new CashEntryService(_repositoryUoW);
                return cashEntryService;
            }
        }

        public DailyBalanceService DailyBalanceService
        {
            get
            {
                if (dailyBalanceService is null)
                    dailyBalanceService = new DailyBalanceService(_repositoryUoW);
                return dailyBalanceService;
            }
        }
    }
}