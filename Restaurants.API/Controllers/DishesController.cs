using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries;

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
        await _mediator.Send(command);

        return Created();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(IEnumerable<DishDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllDishesForRestaurant(int restaurantId)
    {
        var dishesForRestaurant = await _mediator.Send(new GetDishesForRestaurantQuery(restaurantId));

        return Ok(dishesForRestaurant);
    }
}
