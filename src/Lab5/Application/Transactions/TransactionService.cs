﻿using System.Diagnostics.CodeAnalysis;
using Application.Abstraction.Repositories;
using Application.Contracts.Transactions;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Application.Models.TransactionModel;

namespace Application.Transactions;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly CurrentState _currentState;

    public TransactionService(ITransactionRepository repository, CurrentState currentState)
    {
        _repository = repository;
        _currentState = currentState;
    }

    public async Task<Result> FindUserByCardName(long cardId)
    {
        Task<Transaction?> transactionTask = _repository.FindUserByCardName(cardId);
        Transaction? transaction = await transactionTask.ConfigureAwait(true);

        if (transaction is not null)
        {
            return new Result(new ResultType.Success(), "Success find transaction");
        }

        return new Result(new ResultType.Failure(), "Transaction not found");
    }

    public async Task<Result> GetMoney(long cardId, long amount)
    {
        Task<long> balance = GetAccountBalance();
        if (await balance.ConfigureAwait(true) < amount)
        {
            return new Result(new ResultType.Failure(), "not enough money to get");
        }

        await _repository.UpdateBalance(await balance.ConfigureAwait(true) - amount, _currentState).ConfigureAwait(true);
        return new Result(new ResultType.Success(), string.Empty);
    }

    public async Task<Result> DepositMoney(long cardId, long amount)
    {
        Task<long> balance = GetAccountBalance();
        await _repository.UpdateBalance(await balance + amount, _currentState);
        return new Result(new ResultType.Success(), string.Empty);
    }

    public async Task<long> GetAccountBalance()
    {
        return await _repository.GetCardBalance(_currentState);
    }

    public async Task<IEnumerable<Transaction>> GetAllTransaction(long cardId)
    {
        return await _repository.GetAllTransaction(cardId);
    }
}