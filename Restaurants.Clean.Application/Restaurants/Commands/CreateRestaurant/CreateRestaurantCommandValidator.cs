using FluentValidation;
namespace Restaurants.Clean.Application;

public class CreateRestaurantCommandValidator :AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto=> dto.Name)
        .Length(3,100);

        RuleFor(dot=> dot.Discription)
        .NotEmpty().WithMessage("Discription is required");
    }

}
 