namespace Restaurants.Clean.Application;

public class RestaurantsDto
{
    public int Id { get; set; }
    public string Name { get; set; } =default!;
    public string Discription { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string Address { get; set; }
    public List<DishDto> Dishes { get; set; } = new List<DishDto>();

}
