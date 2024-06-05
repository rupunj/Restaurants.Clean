namespace Restaurants.Clean.Application;

public record CurrentUser(string Id,string email,IEnumerable<string> roles)
{
   

}
