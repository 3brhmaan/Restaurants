namespace Restaurants.Domain.Exceptions;
public class DishNotFoundException : NotFoundException
{
    public DishNotFoundException(string message) : base(message)
    {
    }
}
