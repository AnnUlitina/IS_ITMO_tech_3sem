using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Cards;
using Application.Models.CurrentStates;

namespace Presentation.Console.Scenarios.CardScenarios.LoginCard;

public class LoginCardScenarioProvider : IScenarioProvider
{
    private readonly ICardService _service;
    private readonly CurrentState _currentState;

    public LoginCardScenarioProvider(
        ICardService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = _currentState.User is not null ? new LoginCardScenario(_service, _currentState) : null;
        return scenario != null;
    }
}