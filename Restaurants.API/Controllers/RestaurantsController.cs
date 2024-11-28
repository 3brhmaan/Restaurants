using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

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
        var restaurants = await _restaurantsService.GetAllRestaurantsAsync();

        return Ok(restaurants);
    }
}
