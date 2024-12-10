using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<RepositoryDbContext>(opts =>
        {
            opts.UseSqlServer(configuration.GetConnectionString("Default"))
                .EnableSensitiveDataLogging();
        });

        services.AddScoped<IRestaurantSeeder , RestaurantSeeder>();
        services.AddScoped<IRepositoryManager , RepositoryManager>();
        services.AddScoped<IRestaurantsRepository , RestaurantsRepository>();
        services.AddScoped<IDishesRepository , DishesRepository>();
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<RepositoryDbContext>();
    }

}
