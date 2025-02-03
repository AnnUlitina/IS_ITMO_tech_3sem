using Application.Contracts.Cards;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.CardScenarios.AddCard;

public class AddCardScenario : IScenario
{
    private readonly ICardService _cardService;
    private readonly CurrentState _currentState;
    public AddCardScenario(
        ICardService cardService,
        CurrentState currentState)
    {
        _cardService = cardService;
        _currentState = currentState;
    }

    public string Name => "Add a new card";

    public async Task<Task> Run()
    {
        string cardName = AnsiConsole.Prompt(new TextPrompt<string>("Enter your card name, please : "));
        string passwordCard = AnsiConsole.Prompt(new TextPrompt<string>("Enter password for '" + cardName + "': "));

        Task<Result> result = _cardService.LoginCard(cardName, passwordCard);
        Result res = await result.ConfigureAwait(false);

        string message;

        if (res.ResultType == new ResultType.Failure())
        {
            string password = AnsiConsole.Prompt(new TextPrompt<string>($"Confirm your password for '{cardName}': "));

            if (_currentState.User != null)
            {
                await _cardService.CreateCard(cardName, password, _currentState.User.Id).ConfigureAwait(false);
                message = "Card successfully created!";
            }
            else
            {
                message = "User is not authenticated.";
            }
        }
        else if (res.ResultType == new ResultType.Success())
        {
            message = "Card already exists!";
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }

        AnsiConsole.WriteLine(message);
        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}