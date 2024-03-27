using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.HostAggreagte.ValueObjects;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using BubberDinner.Domain.UserAggregate.ValueObjects;

namespace  BubberDinner.Domain.HostAggreagte;


public sealed class Host : AggregateRoot<HostId> 
{

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set;}
    public float AverageRating { get; private set;}
    public UserId UserId { get; private set; }
    private readonly List<MenuId> _menuIds = new();

    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();


    

    private Host(HostId id) : base(id)
    {

    }

}
