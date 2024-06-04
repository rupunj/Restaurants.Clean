using Microsoft.EntityFrameworkCore;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;

public class RestaurantsRepository(RestaurantsDbContext context) : IRestaurantsRepository
{
    public async Task<Restaurant> GetRestaurant(int Id)
    {
       var restaurant = await context.Restaurants.Include(q=> q.Dishes).Where(q=> q.Id == Id).FirstOrDefaultAsync();
       return restaurant;
    }

    public async Task<IEnumerable<Restaurant>> GetRestaurants()
    {
        var Restaurants = await context.Restaurants.Include(q=> q.Address).Include(q=> q.Dishes).Where(q=> q.Id ==1) .ToListAsync();
        return Restaurants;
    }
    public async Task<int> CreateRestaurant(Restaurant restaurant)
    {
        context.Restaurants.Add(restaurant);
        await context.SaveChangesAsync();
        return restaurant.Id;
    }
    public async Task DeleteRestaurant(Restaurant restaurant)
    {
        
        context.Restaurants.Remove(restaurant);
        await context.SaveChangesAsync();
       
    }
    public async Task UpdateRestaurant(Restaurant restaurant)
    {
        context.Restaurants.Update(restaurant);
        await context.SaveChangesAsync();

    }
}
