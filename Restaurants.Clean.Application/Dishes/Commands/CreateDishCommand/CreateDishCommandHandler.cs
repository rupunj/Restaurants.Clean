using MediatR;
using Restaurants.Clean.Domain;
using AutoMapper;
namespace Restaurants.Clean.Application;

public class CreateDishCommandHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper,IDishesRepository dishesRepository,IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<CreateDishCommand,int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var restaurant =await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.Id);

        var dish = mapper.Map<Dish>(request);
        if (!restaurantAuthorizationService.Authorization(restaurant,ResourceOperation.Delete))
        {
            throw new ForbidException(); 
        }
        await dishesRepository.Create(dish);
        return dish.Id;
    }
}
