using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using Application.Abstraction.Repositories;
using Application.Contracts.Users;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;
using Application.Models.UserModel;

namespace Application.Users;

[SuppressMessage("", "CA2007", Justification = "Methods")]
internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentState _currentState;

    public UserService(IUserRepository repository, CurrentState currentState)
    {
        _repository = repository;
        _currentState = currentState;
    }

    public async Task<Result> Login(string username, string password)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        Task<User?> userTask = _repository.FindUserByUsername(username, Convert.ToBase64String(hash));

        User? user = await userTask;

        if (Convert.ToBase64String(hash) == user?.Password)
        {
            _currentState.User = user;
            return new Result(new ResultType.Success(), "successful login");
        }

        return new Result(new ResultType.Failure(), "wrong password");
    }

    public async Task<Result> AddNewUser(string username, string password)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        Task<User?> userTask = _repository.AddNewUser(username, Convert.ToBase64String(hash));
        User? user = await userTask;

        if (user is null)
        {
            return new Result(new ResultType.Failure(), "user '" + username + "' failed added");
        }

        _currentState.User = user;
        return new Result(new ResultType.Success(), "user '" + username + "' success added");
    }

    public async Task<Result> DeleteUser(string username, string password)
    {
        Task<bool> userTask = _repository.DeleteUser(username, password);

        bool delete = await userTask;
        if (delete)
        {
            _currentState.User = null;
            return new Result(new ResultType.Success(), "Success deleted");
        }

        return new Result(new ResultType.Failure(), "delete is failure");
    }
}