using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurant;
public class GetDishForRestaurantQueryHandler
    : IRequestHandler<GetDishForRestaurantQuery , DishDto>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    public GetDishForRestaurantQueryHandler(IRepositoryManager repositoryManager , IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<DishDto> Handle(GetDishForRestaurantQuery request , CancellationToken cancellationToken)
    {
        var restaurant = await _repositoryManager.RestaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
            throw new RestaurantNotFoundException($"restaurant with Id: {request.RestaurantId} doesn't exist");

        var dish = restaurant.Dishes.FirstOrDefault(x => x.Id == request.DishId);
        if(dish is null)
            throw new DishNotFoundException($"dish with Id: {request.DishId} doesn't exist");

        var dishDto = _mapper.Map<DishDto>(dish);

        return dishDto;
    }
}
