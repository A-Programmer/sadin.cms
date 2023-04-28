namespace Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;

public sealed class Subject : ValueObject
{
    private const int MaxLength = 500;
    private Subject(string value)
    {
        Value = value;
    }

    protected Subject()
    {
        
    }

    public static Subject Create(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
            throw new DomainArgumentNullException($"{nameof(subject)} can not be null or whitespace.");
        if (subject.Length > MaxLength)
            throw new DomainValidationException($"{nameof(subject)} can not be more than 500 characters.");
        return new Subject(subject);
    }
    
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}