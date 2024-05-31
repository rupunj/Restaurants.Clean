using Microsoft.Extensions.DependencyInjection;

namespace Restaurants.Clean.Application;

public static class ServiceCollection
{
    public static void ApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantService,RestaurantsService>();

    }

}
