namespace Restaurants.Clean.Domain;

public interface IRestaurantAuthorizationService
{
    bool Authorization(Restaurant restaurant, ResourceOperation  resourceOperation);
}
