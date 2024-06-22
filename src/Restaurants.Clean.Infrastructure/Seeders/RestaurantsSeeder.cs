using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Restaurants.Clean.Domain;
using Restaurants.Clean.Infrastructure.Migrations;

namespace Restaurants.Clean.Infrastructure;

public class RestaurantsSeeder(RestaurantsDbContext dbContext ) :IRestaurantsSeeder
{
    public async Task Seed()
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }
        if ( await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var result = getRestaurants();
                dbContext.Restaurants.AddRange(result);
                dbContext.SaveChanges();
            }
            if (!dbContext.Roles.Any())
            {
                var roles = GetIdentityRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }

        }

    }

    private IEnumerable<Restaurant> getRestaurants()
    {
        Users owner = new Users()
        {
            Email = "seeder@gmail.com"
        };
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
                ],
                Owner = owner
                
                
            }
        ];

        return restaurants;
    }
    private IEnumerable<IdentityRole> GetIdentityRoles()
    {
        List<IdentityRole> roles = [
            new()
            {
                Name = UserRoles.User,
                NormalizedName = UserRoles.User.ToUpper()
            },
            new()
            {
                Name = UserRoles.Owner,
                NormalizedName = UserRoles.Owner.ToUpper()
            },
            new()
            {
                Name = UserRoles.Admin,
                NormalizedName = UserRoles.Admin.ToUpper()
            }
        ];
        return roles;
    }
}
