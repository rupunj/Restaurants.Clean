using Microsoft.AspNetCore.Mvc;

namespace Restaurants.Clean.API;
[Route("api/[controller]")]
[ApiController]
public class RestaurantsController:ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

}
