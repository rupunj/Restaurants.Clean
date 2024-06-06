using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Restaurants.Clean.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Restaurants.Clean.Infrastructure;

public static class ServiceColletion
{
    public static void InfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
       services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConSettings")).EnableSensitiveDataLogging());  

       services.AddIdentityApiEndpoints<Users>()
        .AddRoles<IdentityRole>()
        .AddClaimsPrincipalFactory<RestaurantUserClaimsPrincipalFactory>()
        .AddEntityFrameworkStores<RestaurantsDbContext>();
        
       services.AddScoped<IRestaurantsSeeder, RestaurantsSeeder>();
       services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
       services.AddScoped<IDishesRepository, DishesRepository>();

       services.AddAuthorizationBuilder()
       .AddPolicy(PolicyNames.HasNationality,builder => builder.RequireClaim(ClaimTypes.Nationality,"Sri Lankan","Indian"))
       .AddPolicy(PolicyNames.AtLeast20,builder=> builder.AddRequirements(new MinimumAgeRequierment(20)));

       services.AddScoped<IAuthorizationHandler,MinimumAgeRequiermentHandler>();
       //.AddPolicy(PolicyNames.AtLeast20,builder => builder.RequireClaim(ClaimTypes.DateOfBirth,DateTime.Now.AddYears(-20).ToString("dd/MM/yyyy")));

    }

}
