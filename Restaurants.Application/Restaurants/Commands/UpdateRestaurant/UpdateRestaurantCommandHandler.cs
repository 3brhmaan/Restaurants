using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateRestaurantCommandHandler> _logger;
    public UpdateRestaurantCommandHandler(
        IRepositoryManager repositoryManager ,
        IMapper mapper ,
        ILogger<CreateRestaurantCommandHandler> logger
    )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Handle(UpdateRestaurantCommand request , CancellationToken cancellationToken)
    {
        var restaurant = await _repositoryManager.RestaurantsRepository.GetByIdAsync(request.Id);
        if ( restaurant == null ) 
            throw new RestaurantNotFoundException($"restaurant with Id: {request.Id} doesn't exist");

        _mapper.Map(request , restaurant);

        await _repositoryManager.SaveChangesAsync();
    }
}
