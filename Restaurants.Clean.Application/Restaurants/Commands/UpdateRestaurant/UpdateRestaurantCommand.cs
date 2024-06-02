using AutoMapper;
using MediatR;
using Restaurants.Clean.Domain;
namespace Restaurants.Clean.Application;

public class UpdateRestaurantCommand :IRequest<bool> 
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
public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant == null)
            return false;
        restaurant = mapper.Map<Restaurant>(request);
        await  restaurantsRepository.UpdateRestaurant(restaurant);
        return true;
    }
}
