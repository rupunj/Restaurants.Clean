using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetPaginationRestaurantQueryHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper) : IRequestHandler<GetPaginationRestaurantQuery, PageResult<RestaurantsDto>>
{
    public async Task<PageResult<RestaurantsDto>> Handle(GetPaginationRestaurantQuery request, CancellationToken cancellationToken)
    {
        var (restaurant,TotalCount )= await restaurantsRepository.GetRestaurantPagination(request.SearchQuery,request.PageNumber,request.PageSize,request.SortBy,request.SortDirection);

        var restaurantsDto = mapper.Map<IEnumerable<RestaurantsDto>>(restaurant);
        return new PageResult<RestaurantsDto>(restaurantsDto,TotalCount,request.PageSize,request.PageNumber);
    }
}
