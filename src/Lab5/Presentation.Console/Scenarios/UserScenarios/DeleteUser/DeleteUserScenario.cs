using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Application.Models.UserModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.UserScenarios.DeleteUser;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class DeleteUserScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly CurrentState _currentState;

    public DeleteUserScenario(IUserService userService, CurrentState currentState)
    {
        _userService = userService;
        _currentState = currentState;
    }

    public string Name => "Delete user";

    public async Task<Task> Run()
    {
        string username = AnsiConsole.Prompt(new TextPrompt<string>("Enter the username you want to delete: "));
        string passwordLogin = AnsiConsole.Ask<string>("Enter password for '" + username + "': ");

        Task<Result> resultTask = _userService.Login(username, passwordLogin);
        Result result = await resultTask;

        string message;

        if (_currentState.UserRole == UserRole.Admin)
        {
            if (result.ResultType == new ResultType.Failure())
            {
                message = "User does not exist.";
            }
            else if (result.ResultType == new ResultType.Success())
            {
                bool confirmDeletion = AnsiConsole.Confirm($"Are you sure you want to delete user '{username}'?");

                if (confirmDeletion)
                {
                    string password = AnsiConsole.Prompt(new TextPrompt<string>($"Confirm your password for '{username}': "));
                    await _userService.DeleteUser(username, password);
                    message = "User successfully deleted!";
                }
                else
                {
                    message = $"User '{username}' has not been deleted.";
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            message = "Unfortunately, you have not enough rights to delete a user!";
        }

        AnsiConsole.WriteLine(message);
        System.Console.ReadKey();
        return (Task<Task>)Task.CompletedTask;
    }
}