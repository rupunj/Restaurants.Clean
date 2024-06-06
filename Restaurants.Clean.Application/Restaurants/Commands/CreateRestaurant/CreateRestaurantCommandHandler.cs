using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class CreateRestaurantCommandHandler(IMapper mapper,IRestaurantsRepository restaurantsRepository,IUserContext userContext
,IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<CreateRestaurantCommand, int>
{

    public  async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
       var restaurant = mapper.Map<Restaurant>(request);

       var user = userContext.GetCurrentUser();
       restaurant.OwnerID = user.Id;
       int Id = await restaurantsRepository.CreateRestaurant(restaurant);
       return Id;
    }
}
 