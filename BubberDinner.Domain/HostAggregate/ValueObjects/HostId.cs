using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.HostAggreagte.ValueObjects;

public sealed class HostId : ValueObject
{
    public string Value { get; }

    private HostId(string value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid().ToString());
    }
    public static HostId Create(string value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

