using Microsoft.AspNetCore.Authorization;
using Restaurants.Clean.Application;

namespace Restaurants.Clean.Infrastructure;

public class MinimumAgeRequiermentHandler (IUserContext userContext): AuthorizationHandler<MinimumAgeRequierment>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequierment requirement)
    {
        var CurrentUser = userContext.GetCurrentUser();

        if (CurrentUser?.DateofBirth == null)
        {
            context.Fail();
            return Task.CompletedTask;
        }
        if (CurrentUser.DateofBirth.Value.AddYears(requirement.MinAge) <= DateTime.Today)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
        return Task.CompletedTask;
    }
}
 