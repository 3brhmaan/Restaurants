using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Infrastructure.Repositories;
public class DishesRepository : IDishesRepository
{
    public Task<int> Create(Dish dish)
    {
        throw new NotImplementedException();
    }
}
