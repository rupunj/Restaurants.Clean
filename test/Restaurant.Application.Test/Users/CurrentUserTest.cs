using Restaurants.Clean.Application;
using Restaurants.Clean.Domain;
using FluentAssertions;

namespace Restaurant.Application.Test;

public class CurrentUserTest
{
    [Theory()]
    [InlineData(UserRoles.Admin)]
    public void IsInRole_WithMactchingRole_ShouldReturnTrue(string roleName)
    {
        //arange

        var currentUser = new CurrentUser("1","rupun.cj@gmail.com",[UserRoles.Admin,UserRoles.Owner],null,null);

        //act

        var isInRole = currentUser.IsInRole(roleName);

        //assert
        isInRole.Should().BeTrue();
    }
    [Theory()]
    [InlineData(UserRoles.Owner)]
    public void IsInRole_WithMactchingRole_ShouldReturnFalse(string roleName)
    {
        //arange
        var currentUser = new CurrentUser("1","rupun.cj@gmail.com",[UserRoles.Admin,UserRoles.User],null,null);

        //act
        var isInRole = currentUser.IsInRole(roleName);
        //assert
        isInRole.Should().BeFalse();
    }


}
