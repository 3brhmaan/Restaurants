﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers;
[Route("api/Restaurants")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private readonly IMediator _mediator;
    public RestaurantsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _mediator.Send(new GetAllRestaurantsQuery());

        return Ok(restaurants);
    }

    [HttpGet("{id}" , Name = "GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var restaurant = await _mediator.Send(new GetRestaurantByIdQuery() { Id = id});

        if(restaurant == null) 
            return NotFound();
        else
            return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        int id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById) , new { id } , null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        var isDeleted = await _mediator.Send(new DeleteRestaurantCommand(id));

        if (isDeleted)
            return NoContent();
        else
            return NotFound();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateRestaurant(int id , UpdateRestaurantCommand command)
    {
        command.Id = id;
        bool isUpdated = await _mediator.Send(command);

        if (isUpdated)
            return NoContent();
        else
            return NotFound();
    }
}
