namespace IdentityCore.Domain.ValueObjects;

public sealed class PasswordHash
{
    public string Value {get;}

    private PasswordHash(string value)
    {
        Value = value;
    }

    public static PasswordHash FromHash(string hashedValue)
    {
        if(string.IsNullOrWhiteSpace(hashedValue))
        {
            throw new ArgumentException("Password hash cannot be empty", nameof(hashedValue));
        }

        return new PasswordHash(hashedValue);
    }
}