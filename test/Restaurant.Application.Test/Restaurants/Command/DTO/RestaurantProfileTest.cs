using AutoMapper;
using FluentAssertions;
using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;

namespace Restaurant.Application.Test;

public class RestaurantProfileTest
{
    private IMapper _mapper;
    public RestaurantProfileTest()
    {
         var configuration = new MapperConfiguration(cfg=> 
        {
            cfg.AddProfile<RestaurantsProfile>();
        });

        _mapper = configuration.CreateMapper();
    }
    [Fact]
    public void CreateMap_ForRestaurantToRestaurantDto_mapCorrectly()
    {
        //arrange
        var restaurant = new Restaurants.Clean.Domain.Restaurant()
        {
            Id = 1,
            Name = "Test",
            Discription = "Test",
            ContactEmail = "test@test.com",
            Category = "Italian",
            HasDelivery = true,
            ContactPhone = "0123456789",
            Address = new Address()
            {
                City = "City 1",
                Street = "Street 1",
                PostalCode = "11400"
            }
    
        };
        //act
        var result =_mapper.Map<RestaurantsDto>(restaurant);
        //assert
        result.Id.Should().Be(restaurant.Id);
        result.Name.Should().Be(restaurant.Name);
        result.Discription.Should().Be(restaurant.Discription);
        result.ContactEmail.Should().Be(restaurant.ContactEmail);
        result.Category.Should().Be(restaurant.Category);
        result.Address.Should().Be($"{restaurant.Address.City}  {restaurant.Address.Street}  {restaurant.Address.PostalCode}");
    }

}
