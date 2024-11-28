using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly ILogger<RestaurantsService> _logger;
    public RestaurantsService(
        IRestaurantsRepository restaurantsRepository ,
        ILogger<RestaurantsService> logger
    )
    {
        _restaurantsRepository = restaurantsRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        _logger.LogInformation("Getting All restaurnts");

        var restaurants = await _restaurantsRepository.GetAllAsync();

        return restaurants;
    }
}
