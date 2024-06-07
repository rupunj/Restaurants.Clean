using MediatR;
namespace Restaurants.Clean.Application;

public class GetPaginationRestaurantQuery:IRequest<PageResult<RestaurantsDto>>
{
    public string? SearchQuery { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
