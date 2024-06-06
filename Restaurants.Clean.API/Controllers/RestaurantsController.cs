using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;
using Restaurants.Clean.Infrastructure;

namespace Restaurants.Clean.API;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RestaurantsController(IMediator mediator):ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    // [Authorize(Roles =UserRoles.User,Policy =PolicyNames.AtLeast20)]
    public async  Task<ActionResult<IEnumerable<RestaurantsDto>>> Get([FromQuery] GetAllRestaurantsQuery getAllRestaurantsQuery)
    {
        var restaurants = await mediator.Send(getAllRestaurantsQuery);
        return Ok(restaurants);
    }
    [HttpGet("{Id}")]
    [Authorize(Policy = PolicyNames.HasNationality)]
    public async Task<ActionResult<RestaurantsDto>> Get([FromRoute] int Id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(Id));
        return Ok(restaurant);
    }
    [HttpPost]
    [Authorize(Roles =UserRoles.Owner)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] CreateRestaurantCommand createResturantDto)
    { 
        var restaurantId = await mediator.Send(createResturantDto);
        return CreatedAtAction(nameof(Get), new { Id = restaurantId }, restaurantId);
    }
    [HttpDelete("{Id}")]
    [Authorize(Roles =UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] int Id)
    {
        await mediator.Send(new DeleteRestaurantCommand(Id));
        return NoContent();
    }
    
    [HttpPut("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Delete([FromBody] UpdateRestaurantCommand updateRestaurant)
    {
        await mediator.Send(updateRestaurant);
        return NoContent();
    }

}
