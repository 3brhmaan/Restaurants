using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;
public class GetRestaurantByIdHandler :
    IRequestHandler<GetRestaurantByIdQuery , RestaurantDto>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetRestaurantByIdHandler> _logger;
    public GetRestaurantByIdHandler(IRestaurantsRepository restaurantsRepository , IMapper mapper , ILogger<GetRestaurantByIdHandler> logger)
    {
        _restaurantsRepository = restaurantsRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request , CancellationToken cancellationToken)
    {
        _logger.LogInformation($"getting restaurant {request.Id}");

        var restaurant = await _restaurantsRepository
            .GetByIdAsync(request.Id);

        if(restaurant is null)
            throw new RestaurantNotFoundException($"restaurant with Id: {request.Id} doesn't exist");


        var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

        return restaurantDto;
    }
}
