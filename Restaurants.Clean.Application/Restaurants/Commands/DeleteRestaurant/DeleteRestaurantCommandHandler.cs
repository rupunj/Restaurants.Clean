using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.Id);

        if (!restaurantAuthorizationService.Authorization(restaurant,ResourceOperation.Delete))
        {
            throw new ForbidException(); 
        }

       await restaurantsRepository.DeleteRestaurant(restaurant);
    }
}
