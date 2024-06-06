using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Clean.Domain;

namespace Restaurants.Clean.Infrastructure;

public class RestaurantUserClaimsPrincipalFactory(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<Users, IdentityRole>(userManager, roleManager, options)
{
    public override async Task<ClaimsPrincipal> CreateAsync(Users user)
    {
        var id = await GenerateClaimsAsync(user);
        if(user.Nationality!= null )
        {
            id.AddClaim(new Claim(ClaimTypes.Nationality,user.Nationality));
        }
        if(user.DateOfBirth != null)
        {
            id.AddClaim(new Claim(ClaimTypes.DateOfBirth,user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
        }
        return  new ClaimsPrincipal(id);
    }
}
