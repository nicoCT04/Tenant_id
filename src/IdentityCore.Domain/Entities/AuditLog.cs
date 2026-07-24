namespace IdentityCore.Domain.Entities;

public sealed class AuditLog
{
    public Guid Id { get; private set; }
    public Guid? UserId { get; private set; }
    public string Action { get; private set; }
    public string? Details { get; private set; }
    public DateTimeOffset OccurredAt { get; private set; }

    private AuditLog(Guid id, Guid? userId, string action, string? details, DateTimeOffset occurredAt)
    {
        Id = id;
        UserId = userId;
        Action = action;
        Details = details;
        OccurredAt = occurredAt;
    }

    public static AuditLog Record(Guid? userId, string action, string? details, DateTimeOffset occurredAt)
    {
        return new AuditLog(Guid.NewGuid(), userId, action, details, occurredAt);
    }
}