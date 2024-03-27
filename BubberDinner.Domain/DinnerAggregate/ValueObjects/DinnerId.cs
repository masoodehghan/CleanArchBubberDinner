using BubberDinner.Domain.HostAggreagte.ValueObjects;
using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.DinnerAggregate.ValueObjects;


public sealed class DinnerId : EntityId
{
    private DinnerId(Guid value) : base(value)
    { }
}
