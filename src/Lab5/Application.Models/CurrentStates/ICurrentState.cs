using Application.Models.UserModel;

namespace Application.Models.CurrentStates;

public interface ICurrentState
{
    UserRole UserRole { get; }
}