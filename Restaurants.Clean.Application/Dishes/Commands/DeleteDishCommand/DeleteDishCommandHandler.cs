using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class DeleteDishCommandHandler(IRestaurantsRepository restaurantsRepository,IDishesRepository dishesRepository,IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteDishCommand>
{
    public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.restaurantId);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.restaurantId);
        
        var dishes = restaurant.Dishes;
        if (dishes == null)
        {
            throw new NotFoundException(nameof(dishes),request.restaurantId);
            
        }
        if (!restaurantAuthorizationService.Authorization(restaurant,ResourceOperation.Delete))
        {
            throw new ForbidException(); 
        }
        await dishesRepository.Delete(dishes);
    }
}
