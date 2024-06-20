using FluentValidation;
namespace Restaurants.Clean.Application;

public class UnassignRoleCommandValidator:AbstractValidator<UnassignRoleCommand>
{
    public UnassignRoleCommandValidator()
    {
        RuleFor(role=>role.UserEmail)
        .EmailAddress()
        .NotEmpty();

        RuleFor(role=>role.RoleName)
        .NotEmpty();
    }
}
