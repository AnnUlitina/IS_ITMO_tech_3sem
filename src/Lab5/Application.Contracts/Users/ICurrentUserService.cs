using Application.Models.UserModel;

namespace Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}