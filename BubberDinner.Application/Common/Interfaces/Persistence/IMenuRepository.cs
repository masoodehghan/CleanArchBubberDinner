using BubberDinner.Domain.MenuAggregate;

namespace BubberDinner.Application.Common.Interfaces.Persistence;


public interface IMenuRepository
{
    void Add(Menu menu);
}


