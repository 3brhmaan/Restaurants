using FluentValidation;

namespace Restaurants.Application.Users.Commands.DeleteUserRole;
public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
{
    public DeleteUserRoleCommandValidator()
    {
        RuleFor(x => x.UserEmail)
            .NotEmpty()
            .WithMessage("User Email's Is Required");

        RuleFor(x => x.UserEmail)
            .EmailAddress();


        RuleFor(x => x.RoleName)
            .NotEmpty()
            .WithMessage("Role Is Required");
    }
}
