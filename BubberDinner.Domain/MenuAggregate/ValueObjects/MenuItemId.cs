using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.HostAggreagte.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate.ValueObjects;

/*public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
*/

public sealed class MenuItemId : EntityId
{
    private MenuItemId(Guid value) : base(value)
    { }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new(value);
    }
}
