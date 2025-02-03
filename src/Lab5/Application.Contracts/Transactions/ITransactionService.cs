using Application.Models.ResultModel;
using Application.Models.TransactionModel;

namespace Application.Contracts.Transactions;

public interface ITransactionService
{
    Task<IEnumerable<Transaction>> GetAllTransaction(long cardId);
    Task<Result> FindUserByCardName(long cardId);
    Task<Result> GetMoney(long cardId, long amount);
    Task<Result> DepositMoney(long cardId, long amount);
}