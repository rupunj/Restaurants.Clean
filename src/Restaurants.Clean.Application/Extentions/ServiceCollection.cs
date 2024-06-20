using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
namespace Restaurants.Clean.Application;

public static class ServiceCollection
{
    public static void ApplicationService(this IServiceCollection services)
    {
        var AssemblyService = typeof(ServiceCollection).Assembly;
        services.AddAutoMapper(AssemblyService);
        services.AddValidatorsFromAssembly(AssemblyService).AddFluentValidationAutoValidation();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyService));
        services.AddScoped<IUserContext,UserContext>();

    }

}
