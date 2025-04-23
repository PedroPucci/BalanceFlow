using BalanceFlow.Application.ExtensionError;
using BalanceFlow.Application.Services.Interfaces;
using BalanceFlow.Domain.Entity;
using BalanceFlow.Infrastracture.Repository.RepositoryUoW;
using BalanceFlow.Shared.Logging;
using BalanceFlow.Shared.Validator;
using Serilog;

namespace BalanceFlow.Application.Services
{
    public class CashEntryService : ICashEntryService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public CashEntryService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<CashEntryEntity>> Add(CashEntryEntity cashEntryEntity)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidCashEntry = await IsValidCashEntryRequest(cashEntryEntity);

                if (!isValidCashEntry.Success)
                {
                    Log.Error(LogMessages.InvalidCashEntryInputs());
                    return Result<CashEntryEntity>.Error(isValidCashEntry.Message);
                }

                cashEntryEntity.Description = cashEntryEntity.Description;
                cashEntryEntity.Type = cashEntryEntity.Type;
                cashEntryEntity.Amount = cashEntryEntity.Amount;
                cashEntryEntity.TransactionDate = cashEntryEntity.TransactionDate;
                cashEntryEntity.DailyBalanceId = cashEntryEntity.DailyBalanceId;
                cashEntryEntity.CreatedAt = DateTime.UtcNow; 
                
                var result = await _repositoryUoW.CashEntryRepository.Add(cashEntryEntity);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                
                return Result<CashEntryEntity>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error(LogMessages.AddingCashEntryError(ex));
                transaction.Rollback();
                throw new InvalidOperationException("Error to add a new cash entry");
            }
            finally
            {
                Log.Error(LogMessages.AddingCashEntrySuccess());
                transaction.Dispose();
            }
        }

        public async Task<List<CashEntryEntity>> Get()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<CashEntryEntity> cashEntryEntities = await _repositoryUoW.CashEntryRepository.Get();
                _repositoryUoW.Commit();
                return cashEntryEntities;
            }
            catch (Exception ex)
            {
                Log.Error(LogMessages.GetAllCashEntryError(ex));
                transaction.Rollback();
                throw new InvalidOperationException("Error to loading the list User");
            }
            finally
            {
                Log.Error(LogMessages.GetAllCashEntrySuccess());
                transaction.Dispose();
            }
        }

        private async Task<Result<CashEntryEntity>> IsValidCashEntryRequest(CashEntryEntity cashEntryEntity)
        {
            var requestValidator = await new CashEntryRequestValidator().ValidateAsync(cashEntryEntity);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<CashEntryEntity>.Error(errorMessage);
            }

            return Result<CashEntryEntity>.Ok();
        }
    }
}