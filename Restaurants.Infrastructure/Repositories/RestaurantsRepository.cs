using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories;
internal class RestaurantsRepository : IRestaurantsRepository
{
    private readonly RestaurantDbContext _db;
    public RestaurantsRepository(RestaurantDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await _db.Restaurants.ToListAsync();

        return restaurants;
    }
}

