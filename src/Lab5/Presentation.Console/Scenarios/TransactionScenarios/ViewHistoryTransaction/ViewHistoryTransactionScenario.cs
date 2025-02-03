using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Transactions;
using Application.Models.CurrentStates;
using Application.Models.TransactionModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;

[SuppressMessage("", "CA1305", Justification = "Methods")]
[SuppressMessage("", "SA1117", Justification = "Methods")]
public class ViewHistoryTransactionScenario : IScenario
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public ViewHistoryTransactionScenario(
        CurrentState currentState,
        ITransactionService transactionService)
    {
        _currentState = currentState;
        _transactionService = transactionService;
    }

    public string Name => "View history transactions";

    public async Task<Task> Run()
    {
        if (_currentState.Card != null)
        {
            IEnumerable<Transaction> transactions = await _transactionService.GetAllTransaction(_currentState.Card.Id)
                .ConfigureAwait(false);

            if (transactions.Any())
            {
                SelectionPrompt<Transaction> selector = new SelectionPrompt<Transaction>()
                    .Title("Select date transaction:")
                    .AddChoices(transactions)
                    .UseConverter(x => Convert.ToString(x.TransactionDate));

                Transaction transaction = AnsiConsole.Prompt(selector);

                AnsiConsole.WriteLine($"You selected {transaction.TransactionDate}");

                Table spectre = new Table()
                    .Title($"Transaction '{transaction.TransactionDate}' ")
                    .AddColumn(new TableColumn("Card ID").Centered())
                    .AddColumn(new TableColumn("Transaction act").Centered())
                    .AddColumn(new TableColumn("Transaction date").Centered())
                    .AddRow(
                        Convert.ToString(transaction.CardId),
                        transaction.TransactionName,
                        $"[turquoise4]{transaction.TransactionDate}[/]");

                AnsiConsole.Write(spectre);
            }
            else
            {
                AnsiConsole.WriteLine("No transactions found for the current card!");
            }
        }

        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}