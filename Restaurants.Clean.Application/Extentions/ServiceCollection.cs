using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
namespace Restaurants.Clean.Application;

public static class ServiceCollection
{
    public static void ApplicationService(this IServiceCollection services)
    {
        var AssemblyService = typeof(RestaurantsService).Assembly;
        services.AddScoped<IRestaurantService,RestaurantsService>();
        services.AddAutoMapper(AssemblyService);
        services.AddValidatorsFromAssembly(AssemblyService).AddFluentValidationAutoValidation();

    }

}
