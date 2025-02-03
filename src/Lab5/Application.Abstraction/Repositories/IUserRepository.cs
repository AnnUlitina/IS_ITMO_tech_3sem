using Application.Models.UserModel;

namespace Application.Abstraction.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUsername(string username, string password);
    Task<User?> AddNewUser(string username, string password);

    Task<bool> DeleteUser(string username, string password);
}