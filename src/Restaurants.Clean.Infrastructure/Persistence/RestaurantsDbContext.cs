using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Restaurants.Clean.Domain;


namespace Restaurants.Clean.Infrastructure;

public class RestaurantsDbContext :IdentityDbContext<Users>
{
    public RestaurantsDbContext(DbContextOptions options) : base(options)
    {
    }

    internal DbSet<Restaurant> Restaurants { get;  set; }
    internal DbSet<Address> Addresses { get;set; }
    internal DbSet<Dish> Dishes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       // modelBuilder.ApplyConfiguration(new DishesConfigurations());
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //    optionsBuilder.UseSqlServer("Server=localhost;Database=Restaurant;User Id=sa;Password=Tgb@123+-;Trust Server Certificate=true;");
    // }


}
