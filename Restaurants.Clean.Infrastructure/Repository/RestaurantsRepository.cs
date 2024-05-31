using Microsoft.EntityFrameworkCore;
using Restaurants.Clean.Domain;
using Restaurants.Clean.Infrastructure.Migrations;

namespace Restaurants.Clean.Infrastructure;

public class RestaurantsRepository(RestaurantsDbContext context) : IRestaurantsRepository
{
    public async Task<Restaurant> GetRestaurant(int Id)
    {
       var restaurant = await context.Restaurants.FindAsync(Id);
       return restaurant;
    }

    public async Task<IEnumerable<Restaurant>> GetRestaurants()
    {
        var Restaurants = await context.Restaurants.Include(q=> q.Address).Include(q=> q.Dishes).ToListAsync();
        return Restaurants;
    }
}
