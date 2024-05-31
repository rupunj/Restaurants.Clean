using MediatR;
namespace Restaurants.Clean.Application;

public record DeleteRestaurantCommand(int Id) :IRequest<bool>;
