using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class UnassignRoleCommandHandler(UserManager<Users> userManager,RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignRoleCommand>
{
    public async Task Handle(UnassignRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.UserEmail) ?? throw new NotFoundException(nameof(Users),request.UserEmail);
        var role = await roleManager.FindByNameAsync(request.RoleName) ?? throw new NotFoundException(nameof(IdentityRole),request.RoleName);
        await userManager.RemoveFromRoleAsync(user,role.Name!);
    }
}
