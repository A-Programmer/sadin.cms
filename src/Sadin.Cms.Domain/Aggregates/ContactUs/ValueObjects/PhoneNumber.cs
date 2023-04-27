namespace Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;

public sealed class PhoneNumber : ValueObject
{
    private PhoneNumber(string value)
    {
        Value = value;
    }

    public static PhoneNumber Create(string mobile)
    {
        if (!string.IsNullOrWhiteSpace(mobile) && mobile.IsValidMobile()) throw new DomainValidationException("Phone number is not valid.");
        return new PhoneNumber(mobile);
    }

    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}