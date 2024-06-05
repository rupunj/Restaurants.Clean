using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Restaurants.Clean.Application;

 public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("User context is not available");
        }
        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
           
        }
         var userID = user.FindFirst(c=> c.Type == ClaimTypes.NameIdentifier)!.Value;
         var email = user.FindFirst(c=> c.Type == ClaimTypes.Email)!.Value;
         var roles = user.Claims.Where(c=> c.Type == ClaimTypes.Role)!.Select(c=> c.Value);

         return new CurrentUser(userID, email, roles);
    }

}
