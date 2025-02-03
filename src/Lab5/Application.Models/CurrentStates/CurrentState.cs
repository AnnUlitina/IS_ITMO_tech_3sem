using Application.Models.CardModel;
using Application.Models.UserModel;

namespace Application.Models.CurrentStates;

public class CurrentState : ICurrentState
{
    public User? User { get; set; }
    public Card? Card { get; set; }
    public UserRole UserRole { get; set; } = UserRole.None;
}