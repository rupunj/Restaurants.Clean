using Restaurants.Clean.Infrastructure;
using Restaurants.Clean.Application;
using Serilog;
using Restaurants.Clean.API;
using Restaurants.Clean.Domain;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InfrastructureServices(builder.Configuration);
builder.Services.ApplicationService();

builder .Services.AddScoped<ExceptionMiddleware>();
builder .Services.AddScoped<TimeLoggerMiddleware>();

builder.Services.AddEndpointsApiExplorer();

builder.Host.UseSerilog((context,configuration) => 
configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

var scopes = app.Services.CreateScope();
var seeder = scopes.ServiceProvider.GetRequiredService<IRestaurantsSeeder>();

await seeder.Seed();
app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<TimeLoggerMiddleware>();

app.MapGroup("api/Identity").MapIdentityApi<Users>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

