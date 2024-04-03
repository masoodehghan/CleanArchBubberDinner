using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.MenuAggregate.Events;


public record MenuCreated(Menu Menu) : IDomainEvent;

