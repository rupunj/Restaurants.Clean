using Restaurants.Clean.Infrastructure;
using Restaurants.Clean.Application;
using Serilog;
using Restaurants.Clean.API;
using Restaurants.Clean.Domain;
var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.InfrastructureServices(builder.Configuration);
builder.Services.ApplicationService();

var app = builder.Build();

var scopes = app.Services.CreateScope();
var seeder = scopes.ServiceProvider.GetRequiredService<IRestaurantsSeeder>();

await seeder.Seed();
app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<TimeLoggerMiddleware>();

app.MapGroup("api/Identity").WithTags("Identity").MapIdentityApi<Users>();

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

public partial class Programe{}