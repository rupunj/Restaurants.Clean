using FluentValidation;
namespace Restaurants.Clean.Application;

public class CreateRestaurantCommandValidator :AbstractValidator<CreateRestaurantCommand>
{
    public readonly List<string> ValidCategories=["Italian", "Spanish", "Chinese"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto=> dto.Name)
        .Length(3,100);

        RuleFor(dot=> dot.Discription)
        .NotEmpty().WithMessage("Discription is required");

        RuleFor(dto=> dto.Category)
       .Must(q=> ValidCategories.Contains(q))
       .WithMessage($"Category must be one of {string.Join(",",ValidCategories)}");
    }

}
 