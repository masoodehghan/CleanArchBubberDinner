using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.MenuAggregate;

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
}
