using Application.Models.UserModel;

namespace Application.Models.AdminModels;

public record Admin(long Id, string Username, UserRole Role, string Password);