using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.HostAggreagte.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate.ValueObjects;

// public sealed class MenuSectionId : ValueObject
// {
//     public Guid Value { get; }

//     private MenuSectionId(Guid value)
//     {
//         Value = value;
//     }

//     public static MenuSectionId CreateUnique()
//     {
//         return new(Guid.NewGuid());
//     }

//     public override IEnumerable<object> GetEqualityComponents()
//     {
//         yield return Value;
//     }
// }

public sealed class MenuSectionId : EntityId
{
    private MenuSectionId(Guid value) : base(value)
    { }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
