using GeekShopping.Identity.Enumerations.Base;
using GeekShopping.Identity.Models;

namespace GeekShopping.Identity.Enumerations;

public class IdentityRoleEnumeration : EnumerationBase<IdentityRoleEnumeration, IdentityRole>
{
    public static readonly IdentityRole ADMIN = new(1, "Admin", "ADMIN");
    public static readonly IdentityRole CLIENT = new(2, "Client", "CLIENT");
}
