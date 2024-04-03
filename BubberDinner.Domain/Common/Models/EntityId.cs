using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Common.Models;

public  class EntityId : ValueObject
{
    public Guid Value { get; }

    protected EntityId(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    
        protected EntityId()
        {
        }
#pragma warning restore CS8618


}

