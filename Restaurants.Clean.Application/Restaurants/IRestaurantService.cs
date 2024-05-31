using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Application;

public interface IRestaurantService
{
    Task<IEnumerable<RestaurantsDto>> GetAllRestaurants();
    Task<RestaurantsDto> GetRestaurant(int Id);
    Task<int> CreateRestaurant(CreateResturantDto createResturantDto);

}
