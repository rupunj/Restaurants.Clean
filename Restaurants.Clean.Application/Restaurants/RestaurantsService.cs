using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Application;

public class RestaurantsService(IRestaurantsRepository restaurantsRepository,IMapper mapper ):IRestaurantService
{
    public async Task<IEnumerable<RestaurantsDto>> GetAllRestaurants()
    {
        var Restaurants = await restaurantsRepository.GetRestaurants();
        var RestaurantsDto = mapper.Map<IEnumerable<RestaurantsDto>>(Restaurants);
        return RestaurantsDto;
    }

    public async Task<RestaurantsDto> GetRestaurant(int Id)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(Id);
        var restaurantDto = mapper.Map<RestaurantsDto>(restaurant);
        return restaurantDto;
    }
}
