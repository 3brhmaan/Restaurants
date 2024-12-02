using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;
public class GetDishesForRestaurantQueryHandler
    : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    public GetDishesForRestaurantQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _repositoryManager.RestaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
            throw new RestaurantNotFoundException($"restaurant with Id: {request.RestaurantId} doesn't exist");

        var dishesDto = _mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

        return dishesDto;
    }
}
