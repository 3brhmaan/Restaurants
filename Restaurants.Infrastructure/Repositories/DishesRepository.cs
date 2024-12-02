using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories;
public class DishesRepository : IDishesRepository
{
    private readonly RepositoryDbContext _db;
    public DishesRepository(RepositoryDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(Dish dish)
    {
        await _db.Dishes.AddAsync(dish);
    }

    public Task DeleteAsync(IEnumerable<Dish> dishes)
    {
        _db.Dishes.RemoveRange(dishes);
        return Task.CompletedTask;
    }
}
