using FluentValidation;
namespace Restaurants.Clean.Application;

public class AssignRolesCommandValidator:AbstractValidator<AssignRolesCommand>
{
    public AssignRolesCommandValidator()
    {
        RuleFor(roles=> roles.UserEmail)
        .EmailAddress()
        .NotEmpty();

        RuleFor(role=> role.RoleName)
        .NotEmpty();
        
    }
}
