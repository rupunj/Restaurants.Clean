using Microsoft.EntityFrameworkCore;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;

public class DishesRepository(RestaurantsDbContext dbContext):IDishesRepository
{
    public async Task<int> Create (Dish dish)
    {
        dbContext.Dishes.Add(dish);
        return await dbContext.SaveChangesAsync();

    }
}
