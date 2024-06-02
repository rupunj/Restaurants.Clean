namespace Restaurants.Clean.Domain;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetRestaurants();
    Task<Restaurant> GetRestaurant(int Id);
    Task<int> CreateRestaurant(Restaurant restaurant);
    Task DeleteRestaurant(Restaurant restaurant);
     Task UpdateRestaurant(Restaurant restaurant);

}
