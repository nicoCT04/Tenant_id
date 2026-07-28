using MediatR;

namespace IdentityCore.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Password) : IRequest<Guid>;