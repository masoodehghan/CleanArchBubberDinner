using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : EntityId
{
    private MenuReviewId(Guid value) : base(value)
    {
    }


    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuReviewId Create(Guid value)
    {
        return new(value);
    }
}


