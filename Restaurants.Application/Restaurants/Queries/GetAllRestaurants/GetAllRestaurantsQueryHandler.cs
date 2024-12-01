using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQueryHandler
    : IRequestHandler<GetAllRestaurantsQuery , IEnumerable<RestaurantDto>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILogger<GetAllRestaurantsQueryHandler> _logger;
    private readonly IMapper _mapper;
    public GetAllRestaurantsQueryHandler(IRepositoryManager repositoryManager , ILogger<GetAllRestaurantsQueryHandler> logger , IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request , CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting All restaurnts");

        var restaurants = await _repositoryManager.RestaurantsRepository.GetAllAsync();

        var restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantsDto;
    }
}
