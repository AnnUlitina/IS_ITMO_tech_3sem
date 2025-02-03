using Application.Contracts.Cards;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.CardScenarios.LoginCard;

public class LoginCardScenario : IScenario
{
    private readonly ICardService _cardService;
    private readonly CurrentState _currentState;
    public LoginCardScenario(
        ICardService cardService,
        CurrentState currentState)
    {
        _cardService = cardService;
        _currentState = currentState;
    }

    public string Name => "Login card account with card name";

    public async Task<Task> Run()
    {
        string cardName = AnsiConsole.Ask<string>("Enter your card name");
        string passwordLogin = AnsiConsole.Ask<string>("Enter password for '" + cardName + "': ");

        Task<Result> res = _cardService.LoginCard(cardName, passwordLogin);
        Result result = await res.ConfigureAwait(true);

        string message;

        if (result.ResultType == new ResultType.Failure())
        {
            AnsiConsole.WriteLine("Card not found");
            bool wantToCreateCard = AnsiConsole.Confirm($"Want to create a new card with card name: '{cardName}'?");

            if (wantToCreateCard)
            {
                string password = AnsiConsole.Prompt(new TextPrompt<string>($"Confirm your password for '{cardName}': "));

                if (_currentState.User != null)
                {
                    await _cardService.CreateCard(cardName, password, _currentState.User.Id).ConfigureAwait(true);
                    message = "Card successfully registered!";
                }
                else
                {
                    message = "User is not authenticated.";
                }
            }
            else
            {
                message = $"Card '{cardName}' has not been created.";
            }
        }
        else if (result.ResultType == new ResultType.Success())
        {
            message = "Successful login!";
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