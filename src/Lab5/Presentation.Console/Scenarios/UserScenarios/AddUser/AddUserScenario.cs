using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Application.Models.UserModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.UserScenarios.AddUser;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class AddUserScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly CurrentState _currentState;
    public AddUserScenario(
        IUserService userService,
        CurrentState currentState)
    {
        _userService = userService;
        _currentState = currentState;
    }

    public string Name => "Add user";

    public async Task<Task> Run()
    {
        string username = AnsiConsole.Prompt(new TextPrompt<string>("Enter your username"));
        string passwordLogin = AnsiConsole.Prompt(new TextPrompt<string>("Enter password for '" + username + "': "));

        Task<Result> resultTask = _userService.Login(username, passwordLogin);
        Result result = await resultTask;

        string message;
        if (_currentState.User != null && _currentState.UserRole == UserRole.Admin)
        {
            if (result.ResultType == new ResultType.Failure())
            {
                string password = AnsiConsole.Prompt(new TextPrompt<string>($"Confirm your password for '{username}': "));
                await _userService.AddNewUser(username, password);
                message = "User successfully registered!";
            }
            else if (result.ResultType == new ResultType.Success())
            {
                message = "User already exists!";
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            message = "You have no rights to create a user";
        }

        AnsiConsole.WriteLine(message);
        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}