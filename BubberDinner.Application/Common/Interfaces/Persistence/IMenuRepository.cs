using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.MenuAggregate.ValueObjects;

namespace BubberDinner.Application.Common.Interfaces.Persistence;


public interface IMenuRepository
{
    Task Add(Menu menu);
    Task<List<Menu>> GetAllMenuAsync();

    Task<Menu?> GetMenuAsync(MenuId menuId);
}


