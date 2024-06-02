using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetAllRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper,ILogger<GetAllRestaurantsQueryHandler> logger) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantsDto>>
{
    public async Task<IEnumerable<RestaurantsDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");
        var Restaurants = await restaurantsRepository.GetRestaurants();
        var RestaurantsDto = mapper.Map<IEnumerable<RestaurantsDto>>(Restaurants);
        return RestaurantsDto;
    }
}
