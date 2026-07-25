using IdentityCore.Domain.Entities;

namespace IdentityCore.Application.Abstractions;

public interface IUserRepository
{
    Task<bool> ExistByEmailAsync(string email, CancellationToken cancellationToken);
    Task AddAsync (User user, CancellationToken cancellationToken);
}