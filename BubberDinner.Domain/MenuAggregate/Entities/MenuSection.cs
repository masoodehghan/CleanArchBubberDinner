using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.MenuAggregate.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{

    private readonly List<MenuItem> _items = new();

    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> menuItems) : base(id: menuSectionId)
    {
        Description = description;
        Name = name;
        _items = menuItems;
    }


    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        return new(MenuSectionId.CreateUnique(), name, description, items ?? []);
    }

#pragma warning disable CS8618
    
        private MenuSection()
        {
        }
#pragma warning restore CS8618

}
