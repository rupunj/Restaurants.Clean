using Microsoft.AspNetCore.Mvc;

namespace Restaurants.Clean.API;
[ApiController]
[Route("api/Restaurants")]
public class RestaurantsController:ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

}
