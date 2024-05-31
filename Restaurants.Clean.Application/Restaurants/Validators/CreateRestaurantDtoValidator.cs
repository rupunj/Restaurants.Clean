using System.Data;
using FluentValidation;
namespace Restaurants.Clean.Application;

public class CreateRestaurantDtoValidator :AbstractValidator<CreateResturantDto>
{
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto=> dto.Name)
        .Length(3,100);

        RuleFor(dot=> dot.Discription)
        .NotEmpty().WithMessage("Discription is required");

        
        
        
    }

}
