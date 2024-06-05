using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class UpdateUserDetailsCommandHandler(IUserContext userContext,IUserStore<Users> userStore) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
       var user = userContext.GetCurrentUser();
       var DbUser = await userStore.FindByIdAsync(user!.Id,cancellationToken);
       if (DbUser == null)  throw new NotFoundException(nameof(Users),user.Id);

       DbUser.DateOfBirth = request.DateOfBirth;
       DbUser.Nationality = request.Nationality;

       await userStore.UpdateAsync(DbUser,cancellationToken);
    }
}

