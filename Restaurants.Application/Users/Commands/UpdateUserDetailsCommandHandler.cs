using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands;
public class UpdateUserDetailsCommandHandler
    : IRequestHandler<UpdateUserDetailsCommand>
{
    private readonly IUserContext userContext;
    private readonly IUserStore<User> userStore;

    public UpdateUserDetailsCommandHandler(IUserContext userContext , IUserStore<User> userStore)
    {
        this.userContext = userContext;
        this.userStore = userStore;
    }

    public async Task Handle(UpdateUserDetailsCommand request , CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var dbUser = await userStore.FindByIdAsync(user.Id , cancellationToken);

        if (dbUser is null)
            throw new NotFoundException($"User with Id: {user.Id} doesn't exist");

        dbUser.DateOfBirth = request.DateOfBirth;
        dbUser.Nationality = request.Nationality;

        await userStore.UpdateAsync(dbUser , cancellationToken);
    }
}
