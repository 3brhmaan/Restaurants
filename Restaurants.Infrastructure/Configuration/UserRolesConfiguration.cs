using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurants.Infrastructure.Configuration;
public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData
        ([
            new()
            {
               UserId = "26924a17-e743-4448-b470-25d2bc56f1e9" ,
               RoleId = "caf823cd-03d5-4f7c-bd2f-ea9d9997ba08"
            },
            new()
            {
               UserId = "fd7b6988-559b-4acf-b8e0-7c6284cbd6a9" ,
               RoleId = "a40ecab9-5e65-4682-94da-20094bd75d4c"
            },
            new()
            {
               UserId = "4dd8f193-e496-48aa-b667-285df6493294" ,
               RoleId = "2cb604f2-c562-4237-8fb7-76561a77d9bf"
            }
        ]);
    }
}
