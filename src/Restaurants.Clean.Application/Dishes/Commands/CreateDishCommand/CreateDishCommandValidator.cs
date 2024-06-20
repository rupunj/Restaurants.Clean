using FluentValidation;
namespace Restaurants.Clean.Application;

public class CreateDishCommandValidator:AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(q=> q.Price)
        .GreaterThan(0)
        .WithMessage("Price should be grater than 0");

        RuleFor(q=> q.KilloCal)
        .GreaterThan(0)
        .WithMessage("KilloCal should be grater than 0");

        RuleFor(q=> q.Name)
        .Length(3,100);

        RuleFor(q=> q.Description)
        .NotEmpty().WithMessage("Description is required");
    }
}
