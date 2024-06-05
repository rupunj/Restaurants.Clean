﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Restaurants.Clean.Domain;
using Microsoft.AspNetCore.Identity;

namespace Restaurants.Clean.Infrastructure;

public static class ServiceColletion
{
    public static void InfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
       services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConSettings")).EnableSensitiveDataLogging());  

       services.AddIdentityApiEndpoints<Users>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<RestaurantsDbContext>();
        
       services.AddScoped<IRestaurantsSeeder, RestaurantsSeeder>();
       services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
       services.AddScoped<IDishesRepository, DishesRepository>();

    }

}
