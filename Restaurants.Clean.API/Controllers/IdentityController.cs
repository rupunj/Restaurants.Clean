using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Clean.Application;

namespace Restaurants.Clean.API;

[ApiController]
[Route("api/Identity")]
[Authorize]
public class IdentityController(IMediator mediator):ControllerBase
{
    [HttpPatch("UpdateUser")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand updateUserDetailsCommand)
    {
        await mediator.Send(updateUserDetailsCommand);
        return NoContent();
    }

}
