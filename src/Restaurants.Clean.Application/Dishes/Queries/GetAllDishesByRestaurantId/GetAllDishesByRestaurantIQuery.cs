using MediatR;
namespace Restaurants.Clean.Application;

public record GetAllDishesByRestaurantIQuery (int restaurantId):IRequest<IEnumerable<DishDto>>;
