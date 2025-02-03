using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Cards;
using Application.Models.CurrentStates;

namespace Presentation.Console.Scenarios.CardScenarios.ViewInformationCard;

public class ViewInformationScenarioProvider : IScenarioProvider
{
    private readonly ICardService _service;
    private readonly CurrentState _currentState;

    public ViewInformationScenarioProvider(
        ICardService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = (_currentState.User is not null && _currentState.Card is not null)
            ? new ViewInformationScenario(_service, _currentState)
            : null;

        return scenario != null;
    }
}