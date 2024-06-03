using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.Id);

       await restaurantsRepository.DeleteRestaurant(restaurant);
    }
}
