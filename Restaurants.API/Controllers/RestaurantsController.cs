using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers;
[Route("api/Restaurants")]
[ApiController]
[Authorize]
public class RestaurantsController : ControllerBase
{
    private readonly IMediator _mediator;
    public RestaurantsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(IEnumerable<RestaurantDto>))]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _mediator.Send(new GetAllRestaurantsQuery());

        return Ok(restaurants);
    }

    [HttpGet("{id}" , Name = "GetById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(RestaurantDto))]
    public async Task<IActionResult> GetById(int id)
    {
        var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));

        return Ok(restaurant);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Owner)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        int id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById) , new { id } , null);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        await _mediator.Send(new DeleteRestaurantCommand(id));

        return NoContent();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateRestaurant(int id , UpdateRestaurantCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);

        return NoContent();
    }
}
