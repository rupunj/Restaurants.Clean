using MediatR;
namespace Restaurants.Clean.Application;

public class UpdateRestaurantCommand :IRequest 
{
    public int Id { get; set; }
    public string Name { get; set; } =default!;
    public string Discription { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; } 

}
