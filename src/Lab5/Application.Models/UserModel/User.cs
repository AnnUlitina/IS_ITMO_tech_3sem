namespace Application.Models.UserModel;

public record User(long Id, string Username, UserRole UserRole, string Password);