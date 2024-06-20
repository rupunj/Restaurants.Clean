using MediatR;
namespace Restaurants.Clean.Application;

public class UnassignRoleCommand :IRequest
{
    public string UserEmail { get; set; }= default!;
    public string RoleName { get; set; }= default!;

}
