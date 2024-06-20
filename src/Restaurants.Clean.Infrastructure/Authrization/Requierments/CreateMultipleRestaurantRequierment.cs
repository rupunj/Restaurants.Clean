using Microsoft.AspNetCore.Authorization;
using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;

public class CreateMultipleRestaurantRequierment(int numberOfRestaurants) :IAuthorizationRequirement
{
    public int NumOfRestaurant { get;} =numberOfRestaurants;

}
public class CreateMultipleRestaurantRequiermentHandler(IRestaurantsRepository restaurantsRepository, IUserContext userContext) : AuthorizationHandler<CreateMultipleRestaurantRequierment>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CreateMultipleRestaurantRequierment requirement)
    {
        var user = userContext.GetCurrentUser();
        var restaurants = await restaurantsRepository.GetRestaurants();

        int numberOfRestaurants = restaurants.Count(res=>res.OwnerID == user.Id);
        if (numberOfRestaurants > requirement.NumOfRestaurant)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
        
    }
}
