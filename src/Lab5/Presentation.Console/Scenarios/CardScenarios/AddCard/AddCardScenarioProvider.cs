using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Cards;
using Application.Models.CurrentStates;

namespace Presentation.Console.Scenarios.CardScenarios.AddCard;

public class AddCardScenarioProvider : IScenarioProvider
{
    private readonly ICardService _service;
    private readonly CurrentState _currentState;

    public AddCardScenarioProvider(
        ICardService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = _currentState.User is not null
            ? new AddCardScenario(_service, _currentState)
            : null;

        return scenario != null;
    }
}