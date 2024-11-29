using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.API.Controllers;
[Route("api/Restaurants")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private readonly IRestaurantsService _restaurantsService;
    public RestaurantsController(IRestaurantsService restaurantsService)
    {
        _restaurantsService = restaurantsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _restaurantsService.GetAllAsync();

        return Ok(restaurants);
    }

    [HttpGet("{id}" , Name = "GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var restaurant = await _restaurantsService
            .GetByIdAsync(id);

        if(restaurant == null) 
            return NotFound();
        else
            return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantDto dto)
    {
        int id = await _restaurantsService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById) , new { id } , null);
    }
}
