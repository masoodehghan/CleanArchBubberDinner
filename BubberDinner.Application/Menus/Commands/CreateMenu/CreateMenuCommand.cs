using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Menus.CreateMenu.Commands;
public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections
) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> MenuItems
);

public record MenuItemCommand(
    string Name,
    string Description
    
);
