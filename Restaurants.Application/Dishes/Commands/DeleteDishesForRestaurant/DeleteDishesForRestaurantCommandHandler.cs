using AutoMapper;
using MediatR;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishesForRestaurant;
public class DeleteDishesForRestaurantCommandHandler
    : IRequestHandler<DeleteDishesForRestaurantCommand>
{
    private readonly IRepositoryManager _repositoryManager;
    public DeleteDishesForRestaurantCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task Handle(DeleteDishesForRestaurantCommand request , CancellationToken cancellationToken)
    {
        var restaurant = await _repositoryManager.RestaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
            throw new RestaurantNotFoundException($"restaurant with Id: {request.RestaurantId} doesn't exist");

        await _repositoryManager.DishesRepository.DeleteAsync(restaurant.Dishes);
        await _repositoryManager.SaveChangesAsync();
    }
}
