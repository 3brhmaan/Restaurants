namespace Restaurants.Domain.Exceptions;
public class RoleNotFoundException : NotFoundException
{
    public RoleNotFoundException(string roleName) : base(@$"Role [{roleName}] doesn't exist")
    {
    }
}
