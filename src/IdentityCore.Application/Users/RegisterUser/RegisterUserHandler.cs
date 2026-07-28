using IdentityCore.Application.Abstractions;
using IdentityCore.Domain.Entities;
using MediatR;

namespace IdentityCore.Application.Users.RegisterUser;

public sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository userRepository;
    private readonly IPasswordHasher passwordHasher;
    private readonly TimeProvider timeProvider;

    public RegisterUserHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        TimeProvider timeProvider)
    {
        this.userRepository = userRepository;
        this.passwordHasher = passwordHasher;
        this.timeProvider = timeProvider;
    }

    public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var emailAlreadyExists = await userRepository.ExistsByEmailAsync(command.Email, cancellationToken);
        if (emailAlreadyExists)
        {
            throw new InvalidOperationException("Email is already registered.");
        }

        var passwordHash = passwordHasher.Hash(command.Password);
        var user = User.Register(command.Email, passwordHash, timeProvider.GetUtcNow());
        await userRepository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}