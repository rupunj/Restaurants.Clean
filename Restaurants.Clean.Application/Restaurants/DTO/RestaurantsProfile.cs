using AutoMapper;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class RestaurantsProfile :Profile
{
    public RestaurantsProfile()
    {
        CreateMap<Restaurant,RestaurantsDto>()
        .ForMember(p=> p.Address ,opt => opt.MapFrom(src => $"{src.Address.City}  {src.Address.Street}  {src.Address.PostalCode}"));

        CreateMap<CreateRestaurantCommand, Restaurant>()
        .ForMember(p => p.Address, opt => opt.MapFrom(src => new Address { City = src.City, Street = src.Street, PostalCode = src.PostalCode }));
    }

}
