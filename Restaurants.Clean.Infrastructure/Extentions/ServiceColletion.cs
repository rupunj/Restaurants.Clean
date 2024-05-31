using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;

public static class ServiceColletion
{
    public static void InfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
       services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConSettings")));  
       services.AddScoped<IRestaurantsSeeder, RestaurantsSeeder>();
       services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
    }

}
