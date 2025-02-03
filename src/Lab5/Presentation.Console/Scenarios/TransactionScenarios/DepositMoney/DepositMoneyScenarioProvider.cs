using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Transactions;
using Application.Models.CurrentStates;

namespace Presentation.Console.Scenarios.TransactionScenarios.DepositMoney;

public class DepositMoneyScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public DepositMoneyScenarioProvider(
        ITransactionService transactionService,
        CurrentState currentState)
    {
        _transactionService = transactionService;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = (_currentState.Card is not null && _currentState.User is not null)
            ? new DepositMoneyScenario(_transactionService, _currentState)
            : null;

        return scenario != null;
    }
}