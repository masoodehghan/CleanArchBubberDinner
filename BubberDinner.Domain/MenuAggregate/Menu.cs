using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.HostAggreagte.ValueObjects;
using BubberDinner.Domain.MenuAggregate.Entities;
using BubberDinner.Domain.MenuAggregate.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    public HostId _hostId;
    public string Name { get; }
    public string Description { get; }
    public float? AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly(); 

    public Menu(
        MenuId id,
        HostId hostId,
        string name,
        string description,
        List<MenuSection> sections,
        float? averageRating) : base(id)
    {
        
        Name = name;
        _hostId = hostId;
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
        return new(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            sections ?? new(),
            averageRating
            );
    }


}
