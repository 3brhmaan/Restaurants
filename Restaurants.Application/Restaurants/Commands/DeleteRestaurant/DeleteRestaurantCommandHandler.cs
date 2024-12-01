using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
public class DeleteRestaurantCommandHandler
    : IRequestHandler<DeleteRestaurantCommand>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILogger<CreateRestaurantCommandHandler> _logger;

    public DeleteRestaurantCommandHandler(
        IRepositoryManager repositoryManager ,
        ILogger<CreateRestaurantCommandHandler> logger)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
    }

    public async Task Handle(DeleteRestaurantCommand request , CancellationToken cancellationToken)
    {
        var restaurant = await _repositoryManager.RestaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant == null) 
            throw new RestaurantNotFoundException($"restaurant with Id: {request.Id} doesn't exist");

        await _repositoryManager.RestaurantsRepository.DeleteAsync(restaurant);
        await _repositoryManager.SaveChangesAsync();
    }
}
