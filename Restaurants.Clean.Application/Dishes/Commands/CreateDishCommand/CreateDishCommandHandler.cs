using MediatR;
using Restaurants.Clean.Domain;
using AutoMapper;
namespace Restaurants.Clean.Application;

public class CreateDishCommandHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper,IDishesRepository dishesRepository) : IRequestHandler<CreateDishCommand>
{
    public Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var restaurant = restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(restaurant),request.Id);

        var dish = mapper.Map<Dish>(request);
        return dishesRepository.Create(dish);
    }
}
