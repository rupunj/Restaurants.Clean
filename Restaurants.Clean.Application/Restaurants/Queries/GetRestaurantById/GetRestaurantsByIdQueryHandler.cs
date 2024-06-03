using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetRestaurantsByIdQueryHandler(IRestaurantsRepository  restaurantsRepository,IMapper mapper,ILogger<GetRestaurantsByIdQueryHandler> logger) : IRequestHandler<GetRestaurantByIdQuery, RestaurantsDto>
{
    public async Task<RestaurantsDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Get by Id {request.Id}");
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        var restaurantDto = mapper.Map<RestaurantsDto>(restaurant);
        return restaurantDto;
    }
}
