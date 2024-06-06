namespace Restaurants.Clean.Application;

public record CurrentUser(string Id,string email,IEnumerable<string> roles,string? Nationality,DateTime? DateofBirth)
{
   

}
