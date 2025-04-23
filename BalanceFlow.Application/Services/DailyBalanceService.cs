using BalanceFlow.Application.ExtensionError;
using BalanceFlow.Application.Services.Interfaces;
using BalanceFlow.Domain.Entity;
using BalanceFlow.Infrastracture.Repository.RepositoryUoW;
using BalanceFlow.Shared.Logging;
using BalanceFlow.Shared.Validator;
using Serilog;

namespace BalanceFlow.Application.Services
{
    public class DailyBalanceService : IDailyBalanceService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public DailyBalanceService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<DailyBalanceEntity>> Add(DailyBalanceEntity dailyBalanceEntity)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidDailyBalance = await IsValidDailyBalanceRequest(dailyBalanceEntity);

                if (!isValidDailyBalance.Success)
                {
                    Log.Error(LogMessages.InvalidDailyBalanceInputs());
                    return Result<DailyBalanceEntity>.Error(isValidDailyBalance.Message);
                }

                dailyBalanceEntity.BalanceDate = DateTime.UtcNow;
                dailyBalanceEntity.TotalDebit = dailyBalanceEntity.TotalDebit;
                dailyBalanceEntity.FinalBalance = dailyBalanceEntity.FinalBalance;

                var result = await _repositoryUoW.DailyBalanceRepository.Add(dailyBalanceEntity);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();

                return Result<DailyBalanceEntity>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error(LogMessages.AddingDailyBalanceError(ex));
                transaction.Rollback();
                throw new InvalidOperationException("Error to add a new daily balance.");
            }
            finally
            {
                Log.Error(LogMessages.AddingDailyBalanceSuccess());
                transaction.Dispose();
            }
        }

        public async Task<List<DailyBalanceEntity>> Get()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<DailyBalanceEntity> dailyBalanceEntities = await _repositoryUoW.DailyBalanceRepository.Get();
                _repositoryUoW.Commit();
                return dailyBalanceEntities;
            }
            catch (Exception ex)
            {
                Log.Error(LogMessages.GetAllDailyBalanceError(ex));
                transaction.Rollback();
                throw new InvalidOperationException("Error to loading the list daily balance");
            }
            finally
            {
                Log.Error(LogMessages.GetAllDailyBalanceSuccess());
                transaction.Dispose();
            }
        }

        private async Task<Result<DailyBalanceEntity>> IsValidDailyBalanceRequest(DailyBalanceEntity dailyBalanceEntity)
        {
            var requestValidator = await new DailyBalanceRequestValidator().ValidateAsync(dailyBalanceEntity);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<DailyBalanceEntity>.Error(errorMessage);
            }

            return Result<DailyBalanceEntity>.Ok();
        }
    }
}