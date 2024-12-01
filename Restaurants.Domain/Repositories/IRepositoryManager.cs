using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories;
public interface IRepositoryManager
{
    public IRestaurantsRepository RestaurantsRepository { get;}
    public IDishesRepository DishesRepository { get;}
    Task SaveChangesAsync();
}
