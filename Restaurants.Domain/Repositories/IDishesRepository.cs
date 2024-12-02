using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories;
public interface IDishesRepository
{
    Task CreateAsync(Dish dish);
    Task DeleteAsync(IEnumerable<Dish> dishes);
}
