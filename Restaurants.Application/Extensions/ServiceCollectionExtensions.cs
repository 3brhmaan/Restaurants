﻿using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using System.Reflection;

namespace Restaurants.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IRestaurantsService , RestaurantsService>();
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
