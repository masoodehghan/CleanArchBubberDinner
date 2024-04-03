using BubberDinner.Domain.MenuAggregate.Events;
using MediatR;

namespace BubberDinner.Application.Authentication.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}