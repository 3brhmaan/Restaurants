using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDishesForRestaurant;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishForRestaurant;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurant/{restaurantId}/dishes")]
public class DishesController : ControllerBase
{
    private readonly IMediator _mediator;
    public DishesController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateDish(int restaurantId , CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        int dishId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDishForRestaurant) , new {
            restaurantId ,
            dishId
        } , null);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(IEnumerable<DishDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllDishesForRestaurant(int restaurantId)
    {
        var dishesForRestaurant = await _mediator.Send(new GetDishesForRestaurantQuery(restaurantId));

        return Ok(dishesForRestaurant);
    }

    [HttpGet("{dishId}")]
    [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(DishDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDishForRestaurant(int restaurantId , int dishId)
    {
        var dishForRestaurant = await _mediator.Send(new GetDishForRestaurantQuery(restaurantId , dishId));

        return Ok(dishForRestaurant);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDishesForRestaurant(int restaurantId)
    {
        await _mediator.Send(new DeleteDishesForRestaurantCommand(restaurantId));

        return NoContent();
    }
}
