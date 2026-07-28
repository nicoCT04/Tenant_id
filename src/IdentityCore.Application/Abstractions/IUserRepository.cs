using IdentityCore.Domain.Entities;

namespace IdentityCore.Application.Abstractions;

public interface IUserRepository
{
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
    Task AddAsync (User user, CancellationToken cancellationToken);
}