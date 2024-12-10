using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.DeleteUserRole;
public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand>
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public DeleteUserRoleCommandHandler(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task Handle(DeleteUserRoleCommand request , CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ?? throw new UserNotFoundException(request.UserEmail);

        if(!await roleManager.RoleExistsAsync(request.RoleName))
            throw new RoleNotFoundException(request.RoleName);

        if(!await userManager.IsInRoleAsync(user , request.RoleName))
            throw new BadRequestException($"User With Email [{request.UserEmail}] doesn't have the specified Role [{request.RoleName}]");

        await userManager.RemoveFromRoleAsync(user , request.RoleName);
    }
}
