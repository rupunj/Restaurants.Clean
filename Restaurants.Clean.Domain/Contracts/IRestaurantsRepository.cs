namespace Restaurants.Clean.Domain;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetRestaurants();
    Task<Restaurant> GetRestaurant(int Id);

}
