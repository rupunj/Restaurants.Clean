using AutoMapper;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class DishesProfile :Profile
{
    public DishesProfile()
    {
        CreateMap<Dish,DishDto>().ReverseMap();
        CreateMap<CreateDishCommand,Dish>();
    }

}
