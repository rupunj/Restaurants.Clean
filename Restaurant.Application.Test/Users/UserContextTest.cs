using System.Security.Claims;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;

namespace Restaurant.Application.Test;

public class UserContextTest
{
    [Fact]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        // arange
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var claims= new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,"1"),
            new Claim(ClaimTypes.Email,"rupun.cj@gmail.com"),
            new Claim(ClaimTypes.Role,UserRoles.Admin),
            new Claim("Nationality","Sri Lankan"),
            new Claim("DateOfBirth" ,DateTime.Now.AddYears(-20).ToString( "yyyy-MM-dd"))
        };

        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
        httpContextAccessorMock.Setup(q=> q.HttpContext).Returns(new DefaultHttpContext
        {
            User = user
        });


        var usercontext = new UserContext(httpContextAccessorMock.Object);
    
        // act
        var currentUser = usercontext.GetCurrentUser();
    
        // assert
        currentUser.Should().NotBeNull();
        currentUser.Id.Should().Be("1");
        currentUser.Nationality.Should().Be("Sri Lankan");
        currentUser.email.Should().Be("rupun.cj@gmail.com");

    }

}
