﻿using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories;
public interface IRestaurantsRepository
{
    Task CreateAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant);
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant> GetByIdAsync(int id);
}
