using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Application.Menus.CreateMenu.Commands;
using BubberDinner.Application.Menus.Queries;
using BubberDinner.Contracts.Menus;
using BubberDinner.Domain.MenuAggregate;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{

    private readonly IMapper _mapper;
    private readonly IMenuRepository _menuRepository;
    private readonly ISender _mediator;

    public MenusController(IMapper mapper, ISender mediator, IMenuRepository menuRepository)
    {
        _mapper = mapper;
        _mediator = mediator;
        _menuRepository = menuRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId
    )
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createdMenu = await _mediator.Send(command);

        return createdMenu.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ListMenu()
    {
        var menus = await _menuRepository.GetAllMenuAsync();

        return Ok(_mapper.Map<List<MenuResponse>>(menus));
    }

    [HttpGet, Route("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetMenu(string id)
    {
        ReadMenuRequest menuRequest = new(id);
        
        var query = _mapper.Map<ReadMenuQuery>(menuRequest);
        var menu = await _mediator.Send(query);

        return menu.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors)
        );

    }

}
