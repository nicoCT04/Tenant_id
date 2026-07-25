using IdentityCore.Application.Abstractions;
using IdentityCore.Domain.ValueObjects;

namespace IdentityCore.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    public PasswordHash Hash(string rawPassword)
    {
        string hashedValue = BCrypt.Net.BCrypt.HashPassword(rawPassword);
        return PasswordHash.FromHash(hashedValue);
    }
}