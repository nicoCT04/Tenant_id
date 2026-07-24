namespace IdentityCore.Domain.Entities;

public sealed class Organization
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Slug { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    private Organization(Guid id, string name, string slug, DateTimeOffset createdAt)
    {
        Id = id;
        Name = name;
        Slug = slug;
        CreatedAt = createdAt;
    }

    private static Organization Create(string name, string slug, DateTimeOffset createdAt)
    {
        return new Organization(Guid.NewGuid(), name, slug, createdAt);
    }

}