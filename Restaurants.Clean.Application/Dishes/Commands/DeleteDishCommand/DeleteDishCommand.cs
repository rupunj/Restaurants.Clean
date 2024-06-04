using MediatR;
namespace Restaurants.Clean.Application;

public record DeleteDishCommand(int restaurantId) :IRequest;
