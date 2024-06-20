namespace Restaurants.Clean.Domain;

public class Address
{
    public int Id { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; } 
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

}

