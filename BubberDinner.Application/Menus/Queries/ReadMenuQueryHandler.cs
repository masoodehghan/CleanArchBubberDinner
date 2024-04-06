using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using ErrorOr;
using FluentResults;
using MediatR;


namespace BubberDinner.Application.Menus.Queries;

public class ReadMenuQueryHandler : IRequestHandler<ReadMenuQuery, ErrorOr<Menu>>
{

    private readonly IMenuRepository _menuRepository;

    public ReadMenuQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(ReadMenuQuery request, CancellationToken cancellationToken)
    {
        MenuId menuId = MenuId.Create(Guid.Parse(request.Id));
        var menu = await _menuRepository.GetMenuAsync(menuId);

        if (menu is null)
        {
            return Errors.Menu.NotFound;
        }
        return menu;
    }

}
