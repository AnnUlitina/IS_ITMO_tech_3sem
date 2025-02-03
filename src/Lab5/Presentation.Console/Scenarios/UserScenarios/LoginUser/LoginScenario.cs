using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Application.Models.ResultModel;
using Spectre.Console;

namespace Presentation.Console.Scenarios.UserScenarios.LoginUser;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public async Task<Task> Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string passwordLogin = AnsiConsole.Ask<string>("Enter password for '" + username + "': ");

        Task<Result> resultTask = _userService.Login(username, passwordLogin);
        Result result = await resultTask;

        string message;

        if (result.ResultType == new ResultType.Failure())
        {
            AnsiConsole.WriteLine("User not found");
            bool wantToCreateUser = AnsiConsole.Confirm($"Want to create a new user with username: '{username}'?");

            if (wantToCreateUser)
            {
                string password = AnsiConsole.Prompt(new TextPrompt<string>($"Confirm your password for '{username}': "));
                await _userService.AddNewUser(username, password);
                message = "User successfully registered!";
            }
            else
            {
                message = "User has not been created";
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