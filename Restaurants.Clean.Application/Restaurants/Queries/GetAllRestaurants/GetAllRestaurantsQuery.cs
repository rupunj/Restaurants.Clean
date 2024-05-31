using MediatR;
namespace Restaurants.Clean.Application;

public class GetAllRestaurantsQuery :IRequest<IEnumerable<RestaurantsDto>>
{

}
