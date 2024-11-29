using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;
public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand , int>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateRestaurantCommandHandler> _logger;

    public CreateRestaurantCommandHandler(
        IRestaurantsRepository restaurantsRepository , 
        IMapper mapper , 
        ILogger<CreateRestaurantCommandHandler> logger
    )
    {
        _restaurantsRepository = restaurantsRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateRestaurantCommand request , CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Restaurant>(request);

        int id = await _restaurantsRepository.CreateAsync(entity);
        return id;
    }
}
