using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistance;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<RestaurantDbContext>(opts =>
        {
            opts.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped<IRestaurantSeeder , RestaurantSeeder>();
    }

}
