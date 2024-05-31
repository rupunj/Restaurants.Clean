namespace Restaurants.Clean.Domain;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetRestaurants();

}
