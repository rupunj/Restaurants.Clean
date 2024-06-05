using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;

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
    [HttpPost("AssignUserRole")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssignUserRole(AssignRolesCommand assignRolesCommand)
    {
        await mediator.Send(assignRolesCommand);
        return NoContent();
    }
    [HttpDelete("UnassignUserRole")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UnassignUserRole(UnassignRoleCommand unassignRoleCommand)
    {
        await mediator.Send(unassignRoleCommand);
        return NoContent();
    }

}
 