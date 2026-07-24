namespace IdentityCore.Domain.Entities;

public sealed class RefreshToken

{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string TokenHash { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset ExpiresAt { get; private set; }
    public DateTimeOffset? RevokedAt { get; private set; }
    public Guid? ReplacedByTokenId { get; private set; }

    private RefreshToken(Guid id, Guid userId, string tokenHash, DateTimeOffset createdAt, DateTimeOffset expiresAt)
    {
        Id = id;
        UserId = userId;
        TokenHash = tokenHash;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
    }

    public static RefreshToken Issue(Guid userId, string tokenHash, DateTimeOffset issuedAt, TimeSpan lifetime)
    {
        return new RefreshToken(Guid.NewGuid(), userId, tokenHash, issuedAt, issuedAt.Add(lifetime));
    }

    public bool IsRevoked => RevokedAt is not null;

    public bool IsExpired(DateTimeOffset currentTime) => currentTime >= ExpiresAt;

    public bool IsActive(DateTimeOffset currentTime) => !IsRevoked && !IsExpired(currentTime);

    public void RotateTo(RefreshToken replacement, DateTimeOffset rotatedAt)
    {
        RevokedAt = rotatedAt;
        ReplacedByTokenId = replacement.Id;
    }
}