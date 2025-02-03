using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Application.Models.CurrentStates;
using Application.Models.UserModel;

namespace Presentation.Console.Scenarios.UserScenarios.DeleteUser;

public class DeleteUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly CurrentState _currentState;

    public DeleteUserScenarioProvider(
        IUserService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = (_currentState.User is not null && _currentState.UserRole == UserRole.Admin)
            ? new DeleteUserScenario(_service, _currentState)
            : null;

        return scenario != null;
    }
}