using IdentityCore.Domain.ValueObjects;

namespace IdentityCore.Application.Abstractions;

public interface IPasswordHasher
{
    PasswordHash Hash(string rawPassword);
}