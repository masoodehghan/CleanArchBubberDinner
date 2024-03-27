using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Common.Models;

public  class EntityId : ValueObject
{
    public Guid Value { get; }

    public EntityId(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

