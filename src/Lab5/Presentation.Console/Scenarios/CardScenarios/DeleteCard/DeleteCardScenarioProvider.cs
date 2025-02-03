using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Cards;
using Application.Models.CurrentStates;

namespace Presentation.Console.Scenarios.CardScenarios.DeleteCard;

public class DeleteCardScenarioProvider : IScenarioProvider
{
    private readonly ICardService _service;
    private readonly CurrentState _currentState;

    public DeleteCardScenarioProvider(
        ICardService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = _currentState.Card is not null ? new DeleteCardScenario(_service, _currentState) : null;
        return scenario != null;
    }
}