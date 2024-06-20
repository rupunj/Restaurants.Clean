using MediatR;
namespace Restaurants.Clean.Application;

public record GetRestaurantByIdQuery(int Id) :IRequest<RestaurantsDto>;
