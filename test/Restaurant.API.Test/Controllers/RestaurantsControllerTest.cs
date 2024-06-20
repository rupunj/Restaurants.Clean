using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Restaurants.Clean.Domain;

namespace Restaurant.API.Test;

public class RestaurantsControllerTest : IClassFixture<WebApplicationFactory<Programe>>
{
    private readonly WebApplicationFactory<Programe> _factory;
    private readonly Mock<IRestaurantsRepository> _restaurantRepository =new();

    public RestaurantsControllerTest(WebApplicationFactory<Programe> factory)
    {
        _factory = factory.WithWebHostBuilder(
            builder=> builder.ConfigureTestServices(service=>
            {
                service.AddSingleton<IPolicyEvaluator,FakePolicyEvaluator>();
                service.Replace(ServiceDescriptor.Scoped(typeof(IRestaurantsRepository),_=> _restaurantRepository.Object));
            })
        );
    }
    [Fact]
    public async Task GetAll_ForValidRequest_Returns200Ok()
    {
        //arrange

        var restaurant = new List<Restaurants.Clean.Domain.Restaurant>()
        {
            new Restaurants.Clean.Domain.Restaurant()
            {
                Id = 1,
                Name = "Test",
                Discription = "Test",
                ContactEmail = "test@test.com",
            }
        };
         _restaurantRepository.Setup(repo=> repo.GetRestaurants()).ReturnsAsync(restaurant);
        var client = _factory.CreateClient();
       

        //act
        var response = await client.GetAsync("/api/Restaurants");

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    [Fact]
    public async Task GetAll_ForInvalidRequest_Returns404NotFound()
    {
        //arrange
        int id = 1222;
        var client = _factory.CreateClient();
         var restaurant = new Restaurants.Clean.Domain.Restaurant()
        {

                Id = 1,
                Name = "Test",
                Discription = "Test",
                ContactEmail = "test@test.com",
            
        };
         _restaurantRepository.Setup(repo=> repo.GetRestaurant(id)).ReturnsAsync((Restaurants.Clean.Domain.Restaurant?)null);
       

        //act
        var response = await client.GetAsync($"/api/Restaurants/{id}");

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
