using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly ILogger<RestaurantsService> _logger;
    private readonly IMapper _mapper;
    public RestaurantsService(
        IRestaurantsRepository restaurantsRepository ,
        ILogger<RestaurantsService> logger,
        IMapper mapper)
    {
        _restaurantsRepository = restaurantsRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int> CreateAsync(CreateRestaurantDto dto)
    {
        var restaurant = _mapper.Map<Restaurant>(dto);

        int id = await _restaurantsRepository.CreateAsync(restaurant);
        return id;
    }
    public async Task<IEnumerable<RestaurantDto>> GetAllAsync()
    {
        _logger.LogInformation("Getting All restaurnts");

        var restaurants = await _restaurantsRepository.GetAllAsync();

        var restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        
        return restaurantsDto;
    }
    public async Task<RestaurantDto> GetByIdAsync(int id)
    {
        _logger.LogInformation($"getting restaurant {id}");

        var restaurant = await _restaurantsRepository
            .GetByIdAsync(id);

        var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
        
        return restaurantDto;
    }
}
