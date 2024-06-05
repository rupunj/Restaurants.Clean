using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class AssignRolesCommandHandler(UserManager<Users> userManager ,RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignRolesCommand>
{
    public async Task Handle(AssignRolesCommand request, CancellationToken cancellationToken)
    {
       var user = await userManager.FindByEmailAsync(request.UserEmail);
       if (user == null)
       {
            throw new NotFoundException(nameof(Users),request.UserEmail);
       }
       var role = await roleManager.FindByNameAsync(request.RoleName) ?? throw new NotFoundException(nameof(IdentityRole),request.RoleName);
       await userManager.AddToRoleAsync(user,role.Name!);
    }
}
