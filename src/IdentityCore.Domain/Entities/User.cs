namespace IdentityCore.Domain.Entities;

public sealed class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    private User(Guid id, string email, string passwordHash, bool isEmailVerified, DateTimeOffset createdAt)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        IsEmailVerified = isEmailVerified;
        CreatedAt = createdAt;
    }

    public static User Register(string email, string passwordHash, DateTimeOffset registeredAt)
    {
        return new User(Guid.NewGuid(), email, passwordHash, false, registeredAt);
    }

    public void VerifyEmail()
    {
        IsEmailVerified = true;
    }

    public void ChangePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
    }
}