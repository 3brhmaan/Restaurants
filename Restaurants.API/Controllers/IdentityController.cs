using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.API.ActionFilters;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Application.Users.Commands.DeleteUserRole;
using Restaurants.Application.Users.Commands.UpdateUserDetails;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController : ControllerBase
{
    private readonly IMediator mediator;
    public IdentityController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }


    [HttpPost("UserRole")]
    [Authorize(Roles = UserRoles.Admin)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }


    [HttpDelete("UserRole")]
    [Authorize(Roles = UserRoles.Admin)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UnassignUserRole(DeleteUserRoleCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }

}
