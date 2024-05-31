using Microsoft.AspNetCore.Mvc;
using Restaurants.Clean.Application;

namespace Restaurants.Clean.API;
[Route("api/[controller]")]
[ApiController]
public class RestaurantsController(IRestaurantService restaurantService):ControllerBase
{
    [HttpGet]
    public async  Task<IActionResult> Get()
    {
        var restaurants = await restaurantService.GetAllRestaurants();
        return Ok(restaurants);
    }

}
