using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Moq;
using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;
using Restaurants.Clean.Infrastructure;

namespace Restaurant.Infrastructure.Test;

public class CreateMultipleRestaurantRequiermentTest
{
    [Fact]
    public async void HandleRequiermentAsync_UserHasCreateMulitpleRestaurants_ShouldSucceed()
    {
        //arange
        var usercontext = new Mock<IUserContext>();
        var CurrentUser = new CurrentUser("1","rupunj@gmail.com",[],null,null);
        usercontext.Setup(repo=> repo.GetCurrentUser()).Returns(CurrentUser);

        var restaurantsRepository = new Mock<IRestaurantsRepository>();
        var restaurants = new List<Restaurants.Clean.Domain.Restaurant>()
        {
            new Restaurants.Clean.Domain.Restaurant()
            {
                Id = 1,
                OwnerID = "1"
            },
            new Restaurants.Clean.Domain.Restaurant()
            {
                Id = 2,
                OwnerID = "1"
            },
            new Restaurants.Clean.Domain.Restaurant()
            {
                Id = 3,
                OwnerID = "1"
            }
        };

        restaurantsRepository.Setup(repo=> repo.GetRestaurants())
            .ReturnsAsync(restaurants);

        var requierment = new CreateMultipleRestaurantRequierment(2);

        var handler = new CreateMultipleRestaurantRequiermentHandler
            (restaurantsRepository.Object,
            usercontext.Object);

        var context = new AuthorizationHandlerContext([requierment],null,null);


        //act
        await handler.HandleAsync(context);

        //assert
        context.HasSucceeded.Should().BeTrue();


    }
        [Fact]
    public async void HandleRequiermentAsync_UserHasCreateMulitpleRestaurants_ShouldnotSucceed()
    {
        //arange
        var usercontext = new Mock<IUserContext>();
        var CurrentUser = new CurrentUser("1","rupunj@gmail.com",[],null,null);
        usercontext.Setup(repo=> repo.GetCurrentUser()).Returns(CurrentUser);

        var restaurantsRepository = new Mock<IRestaurantsRepository>();
        var restaurants = new List<Restaurants.Clean.Domain.Restaurant>()
        {
            new Restaurants.Clean.Domain.Restaurant()
            {
                Id = 1,
                OwnerID = "1"
            },
            new Restaurants.Clean.Domain.Restaurant()
            {
                Id = 2,
                OwnerID = "2"
            },
            new Restaurants.Clean.Domain.Restaurant()
            {
                Id = 3,
                OwnerID = "3"
            }
        };

        restaurantsRepository.Setup(repo=> repo.GetRestaurants())
            .ReturnsAsync(restaurants);

        var requierment = new CreateMultipleRestaurantRequierment(2);

        var handler = new CreateMultipleRestaurantRequiermentHandler
            (restaurantsRepository.Object,
            usercontext.Object);

        var context = new AuthorizationHandlerContext([requierment],null,null);


        //act
        await handler.HandleAsync(context);

        //assert
        context.HasSucceeded.Should().BeFalse();


    }

}
