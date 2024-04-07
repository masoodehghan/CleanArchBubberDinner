using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.DinnerAggregate.Enums;
using BubberDinner.Domain.DinnerAggregate.ValueObjects;

namespace BubberDinner.Domain.DinnerAggregate;


public sealed class Dinner : AggregateRoot<DinnerId>
{


    public string Name { get; private set; }
    public string Description { get; private set;}
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    public StatusEnum Status { get; private set; } = StatusEnum.Upcoming;
    public bool IsPublic { get; private set; } = false;
    public int MaxGuest { get; private set; }

    private Dinner(DinnerId id) : base(id)
    { }

}
