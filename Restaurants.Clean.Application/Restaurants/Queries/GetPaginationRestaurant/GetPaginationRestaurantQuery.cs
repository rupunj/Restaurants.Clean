using System.ComponentModel;
using System.Runtime.CompilerServices;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetPaginationRestaurantQuery:IRequest<PageResult<RestaurantsDto>>
{
    public string? SearchQuery { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
