using Microsoft.AspNetCore.Authorization;

namespace Restaurants.Clean.Infrastructure;

public class MinimumAgeRequierment(int MinimumAgeRequierment) :IAuthorizationRequirement
{
    public int MinAge { get; } = MinimumAgeRequierment;

}
