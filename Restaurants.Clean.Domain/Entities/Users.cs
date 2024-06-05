using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Restaurants.Clean.Domain;

public class Users :IdentityUser
{
    public DateTime? DateOfBirth { get; set; }
    public string? Nationality { get; set; }

}
