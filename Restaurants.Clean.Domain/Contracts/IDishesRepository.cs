namespace Restaurants.Clean.Domain;

public interface IDishesRepository
{
    Task<int> Create (Dish dish);
    Task Delete (IEnumerable<Dish> dishes);

}
