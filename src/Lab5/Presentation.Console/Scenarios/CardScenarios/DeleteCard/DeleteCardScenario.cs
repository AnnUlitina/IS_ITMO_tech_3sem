using Application.Contracts.Cards;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.CardScenarios.DeleteCard;

public class DeleteCardScenario : IScenario
{
    private readonly ICardService _cardService;
    private readonly CurrentState _currentState;
    public DeleteCardScenario(
        ICardService cardService,
        CurrentState currentState)
    {
        _cardService = cardService;
        _currentState = currentState;
    }

    public string Name => "Delete card";

    public async Task<Task> Run()
    {
        string cardName = AnsiConsole.Prompt(new TextPrompt<string>("Enter your card name"));
        string passwordCard = AnsiConsole.Prompt(new TextPrompt<string>("Enter password for '" + cardName + "': "));

        Task<Result> result = _cardService.LoginCard(cardName, passwordCard);
        Result res = await result.ConfigureAwait(false);

        string message;

        if (res.ResultType == new ResultType.Success())
        {
            bool confirmDeletion = AnsiConsole.Confirm($"Are you sure you want to delete the card?");

            if (confirmDeletion)
            {
                string password = AnsiConsole.Prompt(new TextPrompt<string>($"Confirm your password for '{cardName}': "));

                if (_currentState.User != null)
                {
                    await _cardService.DeleteCard(cardName, password, _currentState.User.Id).ConfigureAwait(false);
                    message = "Card successfully deleted!";
                }
                else
                {
                    message = "User is not authenticated.";
                }
            }
            else
            {
                message = $"Card '{cardName}' has not been deleted.";
            }
        }
        else if (res.ResultType == new ResultType.Failure())
        {
            message = "Card does not exist.";
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