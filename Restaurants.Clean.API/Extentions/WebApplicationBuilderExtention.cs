using Microsoft.OpenApi.Models;
using Serilog;

namespace Restaurants.Clean.API;

public static class WebApplicationBuilderExtention
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddControllers(); 
        builder.Services.AddSwaggerGen(c=> 
        {
            c.AddSecurityDefinition("BearerAuth",new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "BearerAuth"
                        }
                    },[]
                }

            });
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ExceptionMiddleware>();
        builder.Services.AddScoped<TimeLoggerMiddleware>();
        
        builder.Host.UseSerilog((context,configuration) => 
        configuration.ReadFrom.Configuration(context.Configuration));
        builder.Services.AddHttpContextAccessor();
    }

}
