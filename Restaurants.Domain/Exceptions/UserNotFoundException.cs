namespace Restaurants.Domain.Exceptions;
public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string email) : base($"User With Email: [{email}] doesn't exist")
    {
    }
}
