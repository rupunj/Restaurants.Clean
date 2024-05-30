using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Infrastructure;

public class DishesConfigurations : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
       builder.HasData(new Dish{

        Id = 1,
        Name = "Pizza",
        Description = "Pizza with tomato sauce",
        Price = 10,
        RestaurantId = 1


       });
    }
}
