using Application.Models.CurrentStates;
using Application.Models.TransactionModel;

namespace Application.Abstraction.Repositories;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllTransaction(long cardId);
    Task<Transaction?> FindUserByCardName(long cardId);
    Task<long> GetCardBalance(CurrentState currentState);
    Task UpdateBalance(long amount, CurrentState currentState);
}