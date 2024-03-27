using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.MenuAggregate.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{

    private readonly List<MenuItem> _items = new();
    public string Name { get; }
    public string Description { get; }

    public MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Description = description;
        Name = name;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }

}
