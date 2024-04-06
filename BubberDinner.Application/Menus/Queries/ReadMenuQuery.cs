using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.MenuAggregate.Entities;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Menus.Queries;
public record ReadMenuQuery(
    string Id
) : IRequest<ErrorOr<Menu>>;



