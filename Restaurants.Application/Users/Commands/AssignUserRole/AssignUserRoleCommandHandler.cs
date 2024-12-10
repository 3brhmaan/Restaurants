using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.AssignUserRole;
public class AssignUserRoleCommandHandler
    : IRequestHandler<AssignUserRoleCommand>
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public AssignUserRoleCommandHandler(
        UserManager<User> userManager ,
        RoleManager<IdentityRole> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }


    public async Task Handle(AssignUserRoleCommand request , CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ?? throw new UserNotFoundException(request.UserEmail);

        if(!await roleManager.RoleExistsAsync(request.RoleName))
        {
            throw new RoleNotFoundException(request.RoleName);
        }

        await userManager.AddToRoleAsync(user , request.RoleName);
    }
}
