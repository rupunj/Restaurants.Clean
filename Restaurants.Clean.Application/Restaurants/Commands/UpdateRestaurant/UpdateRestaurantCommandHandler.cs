using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper,IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.Id);
        restaurant = mapper.Map<Restaurant>(request);

        if (!restaurantAuthorizationService.Authorization(restaurant,ResourceOperation.Update))
        {
            throw new ForbidException(); 
        }
        await  restaurantsRepository.UpdateRestaurant(restaurant);
        
    }
}
