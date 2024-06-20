using FluentValidation;
using MediatR;
namespace Restaurants.Clean.Application;

public class UpdateUserDetailsCommand :IRequest
{
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }

}

