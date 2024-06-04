using Microsoft.AspNetCore.Mvc;
using MediatR;
using Restaurants.Clean.Application;

namespace Restaurants.Clean.API;

[ApiController]
[Route("api/Restaurans/{restaurantId}/Dishes")]
public class DishesController(IMediator mediator) :ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetDishes([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetAllDishesByRestaurantIQuery(restaurantId));
        return Ok(dishes);
    }
    [HttpGet("{dishId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DishDto>> GetDish([FromRoute] int restaurantId,[FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishByRestaurantIDQuery(restaurantId,dishId));
        return Ok(dish);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId,[FromBody] CreateDishCommand createDishCommand)
    {
        createDishCommand.RestaurantId = restaurantId;
        var dishId = await mediator.Send(createDishCommand);
        return CreatedAtAction(nameof(GetDish), new { restaurantId, dishId},null);
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDish([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteDishCommand(restaurantId));
        return NoContent();
    }

}
