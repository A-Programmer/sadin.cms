namespace Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;

public sealed class Email : ValueObject
{
    private Email(string value)
    {
        Value = value;
    }

    protected Email()
    {
        
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainArgumentNullException($"{nameof(email)} can not be null or whitespace.");
        if (!email.IsValidEmail())
            throw new DomainValidationException("Email is not valid.");
        return new Email(email);
    }
    
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}