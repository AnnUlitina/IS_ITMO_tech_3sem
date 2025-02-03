using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Transactions;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.TransactionScenarios.GetMoney;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class GetMoneyScenario : IScenario
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public GetMoneyScenario(ITransactionService transactionService, CurrentState currentState)
    {
        _transactionService = transactionService;
        _currentState = currentState;
    }

    public string Name => "Get money";

    public async Task<Task> Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter the amount of money you wish to receive: ");

        if (_currentState.User != null)
        {
            Result result = await _transactionService.GetMoney(_currentState.User.Id, amount);

            string message = result.ResultType switch
            {
                ResultType.Success => $"{amount} has been withdrawn from the account",
                ResultType.Failure => $"Failed: {result.Message}",
                _ => throw new ArgumentOutOfRangeException(nameof(result)),
            };

            AnsiConsole.WriteLine(message);
        }

        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}