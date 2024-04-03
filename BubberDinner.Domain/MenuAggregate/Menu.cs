using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.HostAggreagte.ValueObjects;
using BubberDinner.Domain.MenuAggregate.Entities;
using BubberDinner.Domain.MenuAggregate.Events;
using BubberDinner.Domain.MenuAggregate.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    public HostId hostId;
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float? AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly(); 

    private Menu(
        MenuId id,
        HostId hostId,
        string name,
        string description,
        List<MenuSection> sections,
        float? averageRating = null) : base(id)
    {
        
        Name = name;
        this.hostId = hostId;
        Description = description;
        AverageRating = averageRating;
        _sections = sections;
    }

    public static Menu Create(
        HostId hostId,
        string name, 
        string description,
        List<MenuSection>? sections,
        float? averageRating = null
    )
    {
        Menu menu =  new(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            sections ?? new(),
            averageRating
            );

        menu.AddDomainEvent(new MenuCreated(menu));


        return menu;
    }
#pragma warning disable CS8618
    
        private Menu()
        {
        }
#pragma warning restore CS8618

}
