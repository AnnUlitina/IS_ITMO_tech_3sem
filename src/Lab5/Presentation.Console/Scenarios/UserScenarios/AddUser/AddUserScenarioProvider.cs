using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Application.Models.CurrentStates;

namespace Presentation.Console.Scenarios.UserScenarios.AddUser;

public class AddUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly CurrentState _currentState;

    public AddUserScenarioProvider(
        IUserService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = _currentState.User is null
            ? new AddUserScenario(_service, _currentState)
            : null;

        return scenario != null;
    }
}