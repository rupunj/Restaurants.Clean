using System.Runtime.CompilerServices;
using FluentValidation;
using MediatR;
namespace Restaurants.Clean.Application;

public class GetPaginationRestaurantQuery:IRequest<PageResult<RestaurantsDto>>
{
    public string? SearchQuery { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetPaginationRestaurantQueryValidator : AbstractValidator<GetPaginationRestaurantQuery>
{
    private int[] AllowPageSize = [5,10,15,30];
    public GetPaginationRestaurantQueryValidator()
    {
        RuleFor(q=>q.PageNumber)
        .GreaterThanOrEqualTo(1);

        RuleFor(q=>q.PageSize)
        .Must(value=> AllowPageSize.Contains(value))
        .WithMessage($"Page Size must be in [{string.Join(",",AllowPageSize)}]");
    }
}
