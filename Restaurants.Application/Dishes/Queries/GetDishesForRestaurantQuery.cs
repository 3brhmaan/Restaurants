using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries;
public class GetDishesForRestaurantQuery 
    : IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; set; }
    public GetDishesForRestaurantQuery(int restaurantId)
    {
        RestaurantId = restaurantId;
    }
}
