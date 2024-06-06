using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;
public class RestaurantAuthorizationService(IUserContext userContext):IRestaurantAuthorizationService
{
    public bool Authorization(Restaurant restaurant,ResourceOperation  resourceOperation)
    {
        var user = userContext.GetCurrentUser();

        if (resourceOperation == ResourceOperation.Read|| resourceOperation == ResourceOperation.Create)
        {
            return true;
        }
        if (resourceOperation ==ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            return true;
            
        }
        if (resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update && user.Id== restaurant.OwnerID )
        {
            return true;
        }

        return false;

    }

}
