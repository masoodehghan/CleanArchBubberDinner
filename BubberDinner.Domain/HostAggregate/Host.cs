using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Entities;
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




    private Host(
        HostId id,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId,
        List<MenuId> menuIds
        ) : base(id)
    {
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        _menuIds = menuIds;
        FirstName = firstName;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        float AverageRating,
        UserId userId,
        List<MenuId> menuIds)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            AverageRating,
            userId,
            menuIds ?? new());
    }

    #pragma warning disable CS8618
        private Host()
        {}
    #pragma warning restore CS8618
}
