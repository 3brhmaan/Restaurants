using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories;
internal class RestaurantsRepository : IRestaurantsRepository
{
    private readonly RepositoryDbContext _db;
    public RestaurantsRepository(RepositoryDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(Restaurant restaurant)
    {
        await _db.Restaurants.AddAsync(restaurant);
    }

    public async Task DeleteAsync(Restaurant restaurant)
    {
        _db.Restaurants.Remove(restaurant);
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await _db.Restaurants.ToListAsync();

        return restaurants;
    }

    public async Task<Restaurant> GetByIdAsync(int id)
    {
        var restaurant = await _db.Restaurants
            .Include(x => x.Dishes)
            .FirstOrDefaultAsync(x => x.Id == id);

        return restaurant;
    }
}

