using System.Runtime.CompilerServices;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;

namespace Restaurant.Application.Test;

public class UpdateRestaurantCommandHandlerTest
{
    private readonly Mock<IRestaurantsRepository> _restaurantsRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IRestaurantAuthorizationService> _RestaurantAuthorizationServiceMock;
    private readonly UpdateRestaurantCommandHandler _handler;

    public UpdateRestaurantCommandHandlerTest()
    {
        _restaurantsRepositoryMock= new Mock<IRestaurantsRepository>();
        _mapperMock = new Mock<IMapper>();
        _RestaurantAuthorizationServiceMock = new Mock<IRestaurantAuthorizationService>();

        _handler = new UpdateRestaurantCommandHandler(
            _restaurantsRepositoryMock.Object,
            _mapperMock.Object,
            _RestaurantAuthorizationServiceMock.Object);
        
    }
    [Fact]
    public async Task Hadle_ForValidCommand_ShouldUpdateRestaurant()
    {
        //arange


        var restaurant = new Restaurants.Clean.Domain.Restaurant()
        {
            Id =1,
            Name = "test",
            Discription = "test",
            Category = "test",
            HasDelivery = true,
            ContactEmail = "test",
            ContactPhone = "test",
            Address = new Address()
            {
                Street="test",
                City="test",
                PostalCode="test"
            }
        };
        var command = new UpdateRestaurantCommand()
        {
            Id=1,
            Name="test",
            Discription="test",
            Category="test",
            HasDelivery=true,
            ContactEmail="test",
            ContactPhone="test",
            Street="test",
            City="test",
            PostalCode="test"
        };

        _mapperMock.Setup(mapper=> mapper.Map<Restaurants.Clean.Domain.Restaurant>(command)).Returns(restaurant);


        _restaurantsRepositoryMock.Setup(repo=> 
            repo.GetRestaurant(command.Id)).ReturnsAsync(restaurant);

        _RestaurantAuthorizationServiceMock.Setup(repo=> repo.Authorization(restaurant,ResourceOperation.Update)).Returns(true);

        //act
        
        await _handler.Handle(command,CancellationToken.None);

        //assert
        _restaurantsRepositoryMock.Verify(repo => repo.UpdateRestaurant(restaurant), Times.Once);


    }
    [Fact]
    public async void Handle_WithNonExsistingRestaurant_ShouldThrowNotFoundException()
    {
        //arange
        var command = new UpdateRestaurantCommand()
        {
            Id = 1
        };

        _restaurantsRepositoryMock.Setup(repo=> 
            repo.GetRestaurant(command.Id)).ReturnsAsync((Restaurants.Clean.Domain.Restaurant?)null);
        
        //act
        Func<Task> act = async() => await _handler.Handle(command,CancellationToken.None);

        //assert
        await act.Should().ThrowAsync<NotFoundException>()
        .WithMessage($"Restaurant {command.Id} is not found");

    }
    [Fact]
    public async void Handle_WithNonPrivilagedUser_ShouldThrowForbiddenException()
    {
        var command = new UpdateRestaurantCommand()
        {
            Id = 1
        };

       var Restaurant = new Restaurants.Clean.Domain.Restaurant()
       {
            Id=1
       };

       _restaurantsRepositoryMock.Setup(repo=>repo.GetRestaurant(command.Id)).ReturnsAsync(Restaurant);

        _RestaurantAuthorizationServiceMock.Setup(auth=>auth.Authorization(Restaurant,ResourceOperation.Update)).Returns(false);
        
        //act
        Func<Task> act = async() => await _handler.Handle(command,CancellationToken.None);

        //assert
        await act.Should().ThrowAsync<ForbidException>();
    }

     

}
