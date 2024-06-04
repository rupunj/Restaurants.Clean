using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetDishByRestaurantIDQueryHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper) : IRequestHandler<GetDishByRestaurantIDQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByRestaurantIDQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.restaurantId);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.restaurantId);

        var dish = restaurant.Dishes.FirstOrDefault(q=> q.Id == request.dishId);
        if (dish == null)
            throw new NotFoundException(nameof(dish),request.dishId);

        var dishDto = mapper.Map<DishDto>(dish);

        return dishDto;
    }
}
