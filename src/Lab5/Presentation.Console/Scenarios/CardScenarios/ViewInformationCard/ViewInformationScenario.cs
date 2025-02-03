using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Cards;
using Application.Models.CardModel;
using Application.Models.CurrentStates;
using Spectre.Console;

namespace Presentation.Console.Scenarios.CardScenarios.ViewInformationCard;

[SuppressMessage("", "CA1305", Justification = "Methods")]
[SuppressMessage("", "SA1117", Justification = "Methods")]
public class ViewInformationScenario : IScenario
{
    private readonly ICardService _cardService;
    private readonly CurrentState _currentState;

    public ViewInformationScenario(
        ICardService service,
        CurrentState currentState)
    {
        _cardService = service;
        _currentState = currentState;
    }

    public string Name => "View card information";

    public async Task<Task> Run()
    {
        if (_currentState.User != null)
        {
            IEnumerable<Card> cards = await _cardService.GetAllCard(_currentState.User.Id).ConfigureAwait(false);

            if (cards.Any())
            {
                SelectionPrompt<Card> selector = new SelectionPrompt<Card>()
                    .Title("Select card:")
                    .AddChoices(cards)
                    .UseConverter(x => x.CardName);

                Card card = AnsiConsole.Prompt(selector);

                AnsiConsole.WriteLine($"You selected {card.CardName}");

                Table spectre = new Table()
                    .Title($"Card '{card.CardName}' ")
                    .AddColumn(new TableColumn("Card name").Centered())
                    .AddColumn(new TableColumn("Owner name").Centered())
                    .AddColumn(new TableColumn("Card balance").Centered())
                    .AddRow(card.CardName, Convert.ToString(_currentState.User.Username), $"[green]{Convert.ToString(card.Bill)}[/]");

                AnsiConsole.Write(spectre);
            }
            else
            {
                AnsiConsole.WriteLine("No cards found for the current user.");
            }
        }

        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}