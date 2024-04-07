using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.DinnerAggregate.ValueObjects;
using BubberDinner.Domain.HostAggreagte.ValueObjects;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using BubberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BubberDinner.Domain.MenuReviewAggregate;


public class MenuReviw : AggregateRoot<MenuReviewId>
{
    public int Rate { get; private set; }

        public string Comment { get; private set; }
    public HostId hostId { get; private set; }
    public MenuId menuId { get; private set; }
    //TODO implement guest id
    public DinnerId dinnerId { get; private set; }

    private  MenuReviw(
        MenuReviewId id,
        int rate,
        string comment,
        HostId hostId,
        MenuId menuId,
        DinnerId dinnerId) : base(id)
    {
        Rate = rate;
        Comment = comment;
        this.hostId = hostId;
        this.menuId = menuId;
        this.dinnerId = dinnerId;
    }

    public static MenuReviw Create(
        int rate,
        string comment,
        HostId hostId,
        MenuId menuId,
        DinnerId dinnerId)
        {
            return new(MenuReviewId.CreateUnique(), rate, comment, hostId, menuId, dinnerId);
        }

    #pragma warning disable CS8618
    
        private MenuReviw()
        {
        }
#pragma warning restore CS8618

}
