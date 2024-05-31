namespace Restaurants.Clean.Application;

public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } =default!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int KilloCal { get; set; }
}
