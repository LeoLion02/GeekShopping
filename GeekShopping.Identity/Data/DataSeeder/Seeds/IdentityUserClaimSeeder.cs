using GeekShopping.Identity.Enumerations;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace GeekShopping.Identity.Data.DataSeeder.Seeds;

public class IdentityUserClaimSeeder
{
    public List<IdentityUserClaim<int>> GetData()
    {
        var adminUser = ApplicationUserEnumeration.ADMIN;
        var clientUser = ApplicationUserEnumeration.ADMIN;

        return new()
        {
            new() { Id = 1, ClaimType = JwtClaimTypes.Name, ClaimValue = adminUser.FullName, UserId = adminUser.Id },
            new() { Id = 2, ClaimType = JwtClaimTypes.GivenName, ClaimValue = adminUser.FirstName, UserId = adminUser.Id },
            new() { Id = 3, ClaimType = JwtClaimTypes.FamilyName, ClaimValue = adminUser.LastName, UserId = adminUser.Id },
            new() { Id = 4, ClaimType = JwtClaimTypes.Role, ClaimValue = "Admin", UserId = adminUser.Id },

            new() { Id = 5, ClaimType = JwtClaimTypes.Name, ClaimValue = clientUser.FullName, UserId = clientUser.Id },
            new() { Id = 6, ClaimType = JwtClaimTypes.GivenName, ClaimValue = clientUser.FirstName, UserId = clientUser.Id },
            new() { Id = 7, ClaimType = JwtClaimTypes.FamilyName, ClaimValue = clientUser.LastName, UserId = clientUser.Id },
            new() { Id = 8, ClaimType = JwtClaimTypes.Role, ClaimValue = "Admin", UserId = clientUser.Id },
        };
    }
}
