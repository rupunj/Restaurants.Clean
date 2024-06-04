using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetAllDishesByRestaurantIQueryHAndler(IRestaurantsRepository restaurantsRepository,IMapper  mapper) : IRequestHandler<GetAllDishesByRestaurantIQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesByRestaurantIQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.restaurantId);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.restaurantId);

        var dishes = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
        return dishes;
    }
}