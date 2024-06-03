using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Restaurants.Clean.API;

[ApiController]
[Route("api/Restaurans/{restaurantId}/Dishes")]
public class DishesController :ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDishes([FromRoute] int restaurantId )
    {
        return Ok();
    }

}
