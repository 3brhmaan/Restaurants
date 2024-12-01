using AutoMapper;
using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;
public class CreateDishCommandHandler
    : IRequestHandler<CreateDishCommand , int>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    public CreateDishCommandHandler(IRepositoryManager repositoryManager , IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateDishCommand request , CancellationToken cancellationToken)
    {
        var restaurant = await _repositoryManager.RestaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null) 
            throw new RestaurantNotFoundException($"restaurant with Id: {request.RestaurantId} doesn't exist");

        var dish = _mapper.Map<Dish>(request);

        await _repositoryManager.DishesRepository.CreateAsync(dish);
        await _repositoryManager.SaveChangesAsync();

        return dish.Id;
    }
}
