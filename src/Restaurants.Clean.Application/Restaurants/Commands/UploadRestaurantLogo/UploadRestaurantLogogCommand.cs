using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class UploadRestaurantLogogCommand :IRequest 
{
    public int restaurantId { get; set; }
    public string FileName { get; set; } =default!;
    public Stream File{ get; set; } =default!;

}

public class UploadRestaurantLogogCommandHAndler(IRestaurantsRepository restaurantsRepository ,
 ILogger<UploadRestaurantLogogCommandHAndler> logger ,
 IRestaurantAuthorizationService restaurantAuthorizationService,
 IBlobStorageService blobStorageService) : IRequestHandler<UploadRestaurantLogogCommand>
{
    public async Task Handle(UploadRestaurantLogogCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Uploading Restaurant Logo  for {request.restaurantId}");
        var restaurant = await restaurantsRepository.GetRestaurant(request.restaurantId);
        if (restaurant == null)
        {
            throw new NotFoundException(nameof(restaurant),request.restaurantId);
        }
        if (!restaurantAuthorizationService.Authorization(restaurant,ResourceOperation.Update))
        {
            throw new ForbidException(); 
        }

        var fileName = await blobStorageService.UploadLogo(request.File,request.FileName);
        restaurant.Logo = fileName;
        await restaurantsRepository.UpdateRestaurant(restaurant);
        logger.LogInformation($"Uploaded Restaurant Logo  for {request.restaurantId},{fileName}");


       
    }
}
