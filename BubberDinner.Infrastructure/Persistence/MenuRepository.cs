using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.MenuAggregate;

namespace BubberDinner.Infrastructure.Persistence;


public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}
