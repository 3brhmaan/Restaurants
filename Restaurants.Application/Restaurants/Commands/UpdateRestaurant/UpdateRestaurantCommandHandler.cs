using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand , bool>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateRestaurantCommandHandler> _logger;
    public UpdateRestaurantCommandHandler(
        IRestaurantsRepository restaurantsRepository ,
        IMapper mapper ,
        ILogger<CreateRestaurantCommandHandler> logger
    )
    {
        _restaurantsRepository = restaurantsRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateRestaurantCommand request , CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id);
        if ( restaurant == null ) 
            return false;

        _mapper.Map(request , restaurant);

        await _restaurantsRepository.SaveChanges();

        return true;
    }
}
