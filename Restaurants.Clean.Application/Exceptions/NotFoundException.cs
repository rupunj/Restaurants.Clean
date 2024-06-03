namespace Restaurants.Clean.Application;

public class NotFoundException(string name, Object key) :Exception($"{name} {key} is not found")
{

}
