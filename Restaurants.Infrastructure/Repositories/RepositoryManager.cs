using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories;
public class RepositoryManager : IRepositoryManager
{
    public IRestaurantsRepository RestaurantsRepository { get;}
    public IDishesRepository DishesRepository { get;}
    private readonly RepositoryDbContext repositoryDbContext;

    public RepositoryManager(
        IDishesRepository dishesRepository , 
        IRestaurantsRepository restaurantsRepository , 
        RepositoryDbContext repositoryDbContext
    )
    {
        DishesRepository = dishesRepository;
        RestaurantsRepository = restaurantsRepository;
        this.repositoryDbContext = repositoryDbContext;
    }

    public async Task SaveChangesAsync()
    {
        await repositoryDbContext.SaveChangesAsync();
    }
}
