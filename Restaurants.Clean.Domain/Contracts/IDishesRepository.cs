namespace Restaurants.Clean.Domain;

public interface IDishesRepository
{
    Task<int> Create (Dish dish);
  

}
