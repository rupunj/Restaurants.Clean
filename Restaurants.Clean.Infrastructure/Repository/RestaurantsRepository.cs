using Microsoft.EntityFrameworkCore;
using Restaurants.Clean.Domain;
using Restaurants.Clean.Infrastructure.Migrations;

namespace Restaurants.Clean.Infrastructure;

public class RestaurantsRepository(RestaurantsDbContext context) : IRestaurantsRepository
{
    public async Task<IEnumerable<Restaurant>> GetRestaurants()
    {
        var Restaurants = await context.Restaurants.ToListAsync();
        return Restaurants;
    }
}
