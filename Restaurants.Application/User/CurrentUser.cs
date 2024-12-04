namespace Restaurants.Application.User;
public class CurrentUser
{
    public string Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; }
    public CurrentUser(IEnumerable<string> roles , string email , string id)
    {
        Roles = roles;
        Email = email;
        Id = id;
    }

    public bool IsInRole(string role) => Roles.Contains(role);
}
