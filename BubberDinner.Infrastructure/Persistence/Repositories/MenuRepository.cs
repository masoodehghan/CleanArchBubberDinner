using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BubberDinner.Infrastructure.Persistence.Repositories;


public class MenuRepository : IMenuRepository
{

    private readonly BubberDinnerDbContext _dbContext;

    public MenuRepository(BubberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Menu menu)
    {
        _dbContext.Add(menu);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Menu>> GetAllMenuAsync()
    {
        return await _dbContext.Menu.Include(s => s.Sections)
            .ThenInclude(s => s.Items)
            .ToListAsync();
    }

    public async Task<Menu?> GetMenuAsync(MenuId menuId)
    {
        return await _dbContext.Menu.FirstOrDefaultAsync(s => s.Id == menuId);
    }
}
