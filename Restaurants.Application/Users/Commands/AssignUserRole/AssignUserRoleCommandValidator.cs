using FluentValidation;

namespace Restaurants.Application.Users.Commands.AssignUserRole;
public class AssignUserRoleCommandValidator 
    : AbstractValidator<AssignUserRoleCommand>
{
    public AssignUserRoleCommandValidator()
    {
        RuleFor(x => x.UserEmail)
            .NotEmpty()
            .WithMessage("User Email Is Required");

        RuleFor(x => x.RoleName)
            .NotEmpty()
            .WithMessage("User Role Is Required");
    }
}
