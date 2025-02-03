using Application.Contracts.Users;
using Application.Models.UserModel;

namespace Application.Users;

public sealed class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}