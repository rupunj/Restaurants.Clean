using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetAllRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantsDto>>
{
    public async Task<IEnumerable<RestaurantsDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        var Restaurants = await restaurantsRepository.GetRestaurants();
        var RestaurantsDto = mapper.Map<IEnumerable<RestaurantsDto>>(Restaurants);
        return RestaurantsDto;
    }
}
