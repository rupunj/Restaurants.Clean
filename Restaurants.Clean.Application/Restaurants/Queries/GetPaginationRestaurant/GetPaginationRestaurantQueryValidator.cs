using FluentValidation;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class GetPaginationRestaurantQueryValidator : AbstractValidator<GetPaginationRestaurantQuery>
{
    private int[] AllowPageSize = [5,10,15,30];
    private string[] allowSortColumns = [nameof(Restaurant.Name), nameof(Restaurant.Discription), nameof(Restaurant.Category)];
    public GetPaginationRestaurantQueryValidator()
    {
        RuleFor(q=>q.PageNumber)
        .GreaterThanOrEqualTo(1);

        RuleFor(q=>q.PageSize)
        .Must(value=> AllowPageSize.Contains(value))
        .WithMessage($"Page Size must be in [{string.Join(",",AllowPageSize)}]");

        RuleFor(q=>q.SortBy)
        .Must(value=> allowSortColumns.Contains(value))
        .When(q=>q.SortBy != null)
        .WithMessage($"Sort By is optional,or  must be in [{string.Join(",",allowSortColumns)}]");
    }
}
