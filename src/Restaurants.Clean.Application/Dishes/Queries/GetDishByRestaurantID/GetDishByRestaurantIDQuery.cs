using MediatR;
namespace Restaurants.Clean.Application;

public record GetDishByRestaurantIDQuery(int restaurantId , int dishId):IRequest<DishDto>;
