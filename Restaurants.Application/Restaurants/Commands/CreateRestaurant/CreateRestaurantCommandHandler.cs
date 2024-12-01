using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;
public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand , int>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateRestaurantCommandHandler> _logger;

    public CreateRestaurantCommandHandler(
        IRepositoryManager repositoryManager , 
        IMapper mapper , 
        ILogger<CreateRestaurantCommandHandler> logger
    )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateRestaurantCommand request , CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Restaurant>(request);

        int id = await _repositoryManager.RestaurantsRepository.CreateAsync(entity);
        await _repositoryManager.SaveChangesAsync();

        return id;
    }
}
