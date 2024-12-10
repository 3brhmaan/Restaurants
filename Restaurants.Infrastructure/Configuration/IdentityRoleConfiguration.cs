using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurants.Domain.Constants;

namespace Restaurants.Infrastructure.Configuration;
public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        List<IdentityRole> roles =
        [
            new(UserRoles.User),
            new(UserRoles.Admin),
            new(UserRoles.Owner)
        ];

        builder.HasData(roles);
    }
}
