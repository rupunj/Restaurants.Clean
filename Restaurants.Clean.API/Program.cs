using Restaurants.Clean.Infrastructure;
using Restaurants.Clean.Application;
using Serilog;
using Serilog.Events;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InfrastructureServices(builder.Configuration);
builder.Services.ApplicationService();

builder.Services.AddSerilog((context,configuration) => 
configuration
.MinimumLevel.Override("Microsoft",LogEventLevel.Warning)
.WriteTo.Console());



var app = builder.Build();

var scopes = app.Services.CreateScope();
var seeder = scopes.ServiceProvider.GetRequiredService<IRestaurantsSeeder>();

await seeder.Seed();

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

