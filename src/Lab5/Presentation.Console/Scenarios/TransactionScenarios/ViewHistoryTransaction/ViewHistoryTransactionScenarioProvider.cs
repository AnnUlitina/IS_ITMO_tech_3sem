using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Transactions;
using Application.Models.CurrentStates;

namespace Presentation.Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;

public class ViewHistoryTransactionScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public ViewHistoryTransactionScenarioProvider(
        ITransactionService transactionService,
        CurrentState currentState)
    {
        _transactionService = transactionService;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = (_currentState.Card is not null && _currentState.User is not null)
            ? new ViewHistoryTransactionScenario(_currentState, _transactionService)
            : null;

        return scenario != null;
    }
}