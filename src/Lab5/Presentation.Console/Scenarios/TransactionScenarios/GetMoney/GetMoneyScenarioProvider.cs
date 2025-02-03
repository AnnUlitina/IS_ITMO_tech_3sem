using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Transactions;
using Application.Models.CurrentStates;

namespace Presentation.Console.Scenarios.TransactionScenarios.GetMoney;

public class GetMoneyScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public GetMoneyScenarioProvider(
        ITransactionService transactionService,
        CurrentState currentState)
    {
        _transactionService = transactionService;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = (_currentState.Card is not null && _currentState.User is not null)
            ? new GetMoneyScenario(_transactionService, _currentState)
            : null;

        return scenario != null;
    }
}