using Application.Models.ResultModel;

namespace Application.Contracts.Users;

public interface IUserService
{
    Task<Result> Login(string username, string password);
    Task<Result> AddNewUser(string username, string password);

    Task<Result> DeleteUser(string username, string password);
}