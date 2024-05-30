using Microsoft.Identity.Client;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;

public class RestaurantsSeeder(RestaurantsDbContext dbContext ) :IRestaurantsSeeder
{
    public async Task Seed()
    {
        if ( await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var result = getRestaurants();
                dbContext.Restaurants.AddRange(result);
                dbContext.SaveChanges();
            }
        }

    }

    private IEnumerable<Restaurant> getRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
            {
                Name = "Restaurant 1",
                ContactEmail = "restaurant1@gmail.com",
                ContactPhone = "0123456789",
                Discription = "Discription 1",
                Category = "Category 1",
                HasDelivery = true,
                Address = new()
                {
                    Street = "Street 1",
                    City = "City 1",
                    PostalCode = "11400",
                    
                   
                },
                Dishes = [
                    new()
                    {
                        Name = "Dish 1",
                        Description = "Description 1",
                        KilloCal = 101,
                        Price = 100,
                        
                    }
                ]
                
            }
        ];

        return restaurants;
    }
}
