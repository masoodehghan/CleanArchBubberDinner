using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.MenuAggregate.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private MenuItem(
        MenuItemId menuItemId,
        string name,
        string description) : base(id: menuItemId)
    {
        Description = description;
        Name = name;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }

#pragma warning disable CS8618
    
        private MenuItem()
        {
        }
#pragma warning restore CS8618


}
