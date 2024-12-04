using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor httpContextAccessor;
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
        if (user == null)
            throw new InvalidOperationException("User Context isn't found");

        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return null;

        var userId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var userEmail = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

        return new CurrentUser(roles , userEmail , userId);
    }

}
