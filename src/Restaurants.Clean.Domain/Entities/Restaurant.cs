﻿namespace Restaurants.Clean.Domain;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } =default!;
    public string Discription { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public Address Address { get; set; }
    public List<Dish> Dishes { get; set; } = new List<Dish>();
    public Users Owner { get; set; } =  default!;
    public string OwnerID { get; set; }
    public string? Logo { get; set; }
}
