using System.Reflection.Metadata.Ecma335;

namespace Restaurants.Clean.Application;

public record CurrentUser(string Id,string email,IEnumerable<string> roles,string? Nationality,DateTime? DateofBirth)
{

    public bool IsInRole(string roleName) =>roles.Contains(roleName);
   

}
