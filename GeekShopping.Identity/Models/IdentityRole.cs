using Microsoft.AspNetCore.Identity;

namespace GeekShopping.Identity.Models;

public class IdentityRole : IdentityRole<int>
{
    protected IdentityRole() { }

    public IdentityRole(int id, string roleName, string normalizedName) : base(roleName) 
    { 
        Id = id;
        NormalizedName = normalizedName;
    }
}
