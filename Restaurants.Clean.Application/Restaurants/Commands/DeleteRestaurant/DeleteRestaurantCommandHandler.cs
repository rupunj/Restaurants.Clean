using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            return false;

       await restaurantsRepository.DeleteRestaurant(restaurant);
       return true;
    }
}
