using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurant/{restaurantId}/dishes")]
public class DishesController : ControllerBase
{
    private readonly IMediator mediator;
    public DishesController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CreateDish(int restaurantId , CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        await mediator.Send(command);

        return Created();
    }
}
