using GeekShopping.Identity.Enumerations;
using Microsoft.AspNetCore.Identity;

namespace GeekShopping.Identity.Data.DataSeeder.Seeds;

public class IdentityUserRoleSeeder
{
    public List<IdentityUserRole<int>> GetData() => new()
    {
        new() { UserId = ApplicationUserEnumeration.ADMIN.Id, RoleId = IdentityRoleEnumeration.ADMIN.Id },
        new() { UserId = ApplicationUserEnumeration.CLIENT.Id, RoleId = IdentityRoleEnumeration.CLIENT.Id },
    };
}
