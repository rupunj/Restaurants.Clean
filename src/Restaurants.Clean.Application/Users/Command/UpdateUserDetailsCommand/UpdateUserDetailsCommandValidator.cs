using FluentValidation;
namespace Restaurants.Clean.Application;

public class UpdateUserDetailsCommandValidator:AbstractValidator<UpdateUserDetailsCommand>
{
    public UpdateUserDetailsCommandValidator()
    {
        RuleFor(user=> user.DateOfBirth)
        .LessThan(DateTime.Now)
        .WithMessage("Date of birth should be less than current date");

        RuleFor(user=> user.Nationality)
        .NotEmpty()
        .WithMessage("Nationality should be not empty");
    }
}

