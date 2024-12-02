using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurant;
public class GetDishForRestaurantQuery
    : IRequest<DishDto>
{
    public int RestaurantId { get; set; }
    public int DishId { get; set; }

    public GetDishForRestaurantQuery(int restaurantId , int dishId)
    {
        DishId = dishId;
        RestaurantId = restaurantId;
    }
}
