using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Application;

public interface IRestaurantService
{
    Task<IEnumerable<Restaurant>> GetAllRestaurants();

}
