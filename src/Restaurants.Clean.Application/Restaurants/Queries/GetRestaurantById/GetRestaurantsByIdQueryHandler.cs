using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetRestaurantsByIdQueryHandler(IRestaurantsRepository  restaurantsRepository,
IMapper mapper,ILogger<GetRestaurantsByIdQueryHandler> logger,
IBlobStorageService blobStorageService) : IRequestHandler<GetRestaurantByIdQuery, RestaurantsDto>
{
    public async Task<RestaurantsDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Get by Id {request.Id}");
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.Id);
        var restaurantDto = mapper.Map<RestaurantsDto>(restaurant);
        restaurantDto.LogoUrl = blobStorageService.GetBlobSasUrl(restaurant.Logo);
        return restaurantDto;
    }
}
