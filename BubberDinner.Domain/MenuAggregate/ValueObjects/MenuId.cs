// using BubberDinner.Domain.Common.Models;

// namespace BubberDinner.Domain.Menu.ValueObjects;

// public sealed class MenuId : ValueObject
// {
//     public Guid Value { get; }

//     private MenuId(Guid value)
//     {
//         Value = value;
//     }

//     public static MenuId CreateUnique()
//     {
//         return new(Guid.NewGuid());
//     }

//     public override IEnumerable<object> GetEqualityComponents()
//     {
//         yield return Value;
//     }
// }
using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : EntityId
{
    private MenuId(Guid value) : base(value)
    {
    }


    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}


