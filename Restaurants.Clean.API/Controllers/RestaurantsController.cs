using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Clean.Application;

namespace Restaurants.Clean.API;
[Route("api/[controller]")]
[ApiController]
public class RestaurantsController(IMediator mediator):ControllerBase
{
    [HttpGet]
    public async  Task<IActionResult> Get()
    {

        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] int Id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(Id));
        if (restaurant == null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateRestaurantCommand createResturantDto)
    { 
        var restaurantId = await mediator.Send(createResturantDto);
        return CreatedAtAction(nameof(Get), new { Id = restaurantId }, restaurantId);
    }

}
