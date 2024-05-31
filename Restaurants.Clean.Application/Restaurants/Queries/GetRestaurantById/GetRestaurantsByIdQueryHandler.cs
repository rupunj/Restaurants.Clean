using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetRestaurantsByIdQueryHandler(IRestaurantsRepository  restaurantsRepository,IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantsDto>
{
    public async Task<RestaurantsDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        var restaurantDto = mapper.Map<RestaurantsDto>(restaurant);
        return restaurantDto;
    }
}
