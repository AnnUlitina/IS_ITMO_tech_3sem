using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Transactions;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.TransactionScenarios.DepositMoney;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class DepositMoneyScenario : IScenario
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public DepositMoneyScenario(ITransactionService transactionService, CurrentState currentState)
    {
        _transactionService = transactionService;
        _currentState = currentState;
    }

    public string Name => "Deposit money";

    public async Task<Task> Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter the amount of money you wish to deposit: ");

        if (_currentState.User != null)
        {
            Result result = await _transactionService.DepositMoney(_currentState.User.Id, amount);

            switch (result.ResultType)
            {
                case ResultType.Failure:
                    AnsiConsole.WriteLine($"Failed: {result.Message}");
                    break;
                case ResultType.Success:
                    AnsiConsole.Markup($"[green]{amount} added to the account[/]");
                    break;
            }
        }

        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}