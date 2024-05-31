using System.Diagnostics.CodeAnalysis;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Application;

public class RestaurantsService(IRestaurantsRepository restaurantsRepository ):IRestaurantService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        var Restaurants = await restaurantsRepository.GetRestaurants();
        return Restaurants;
    }

}
