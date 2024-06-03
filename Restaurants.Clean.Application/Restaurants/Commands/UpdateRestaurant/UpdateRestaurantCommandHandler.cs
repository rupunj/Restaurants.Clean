using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.Id);
        restaurant = mapper.Map<Restaurant>(request);
        await  restaurantsRepository.UpdateRestaurant(restaurant);
        
    }
}
