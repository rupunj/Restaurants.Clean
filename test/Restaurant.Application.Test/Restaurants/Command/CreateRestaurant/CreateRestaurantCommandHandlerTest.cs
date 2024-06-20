using AutoMapper;
using FluentAssertions;
using Moq;
using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;

namespace Restaurant.Application.Test;

public class CreateRestaurantCommandHandlerTest
{

    [Fact]
    public async  Task  Handle_ForValidCommand_ShouldCreateRestaurant()
    {
        //Arange
        var restaurantsRepositoryMock = new Mock<IRestaurantsRepository>();
        var mapperMock=new Mock<IMapper>();
        var UsercontextMock = new Mock<IUserContext>();

        var command = new CreateRestaurantCommand();
        var restaurant = new Restaurants.Clean.Domain.Restaurant();

        mapperMock.Setup(mapper=>mapper.Map<Restaurants.Clean.Domain.Restaurant>(command)).Returns(restaurant);;


        restaurantsRepositoryMock.Setup
            (repo=> repo.CreateRestaurant
            (It.IsAny<Restaurants.Clean.Domain.Restaurant>()))
            .ReturnsAsync(1);
        
        var currentUser = new CurrentUser("1","rupun.cj@gmail.com",[],null,null);

        UsercontextMock.Setup(repo=> repo.GetCurrentUser()).Returns(currentUser);

        // var commandHandler = new CreateRestaurantCommandHandler(mapperMock.Object,restaurantsRepositoryMock.Object,UsercontextMock.Object);
        var commandHandler = new CreateRestaurantCommandHandler(mapperMock.Object,restaurantsRepositoryMock.Object,UsercontextMock.Object);

        //act

        var result = await commandHandler.Handle(command,CancellationToken.None);

        //assert
        result.Should().Be(1);
        restaurant.OwnerID.Should().Be("1");

        
    }

}
