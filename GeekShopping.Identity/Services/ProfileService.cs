using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using GeekShopping.Identity.Enumerations;
using GeekShopping.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace GeekShopping.Identity.Services;

public class ProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<Models.IdentityRole> _roleManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;

    public ProfileService(
        UserManager<ApplicationUser> userManager,
        RoleManager<Models.IdentityRole> roleManager,
        IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _claimsFactory = claimsFactory;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var id = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(id);

        var claimsPrincipal = await _claimsFactory.CreateAsync(user);
        var claims = claimsPrincipal.Claims.ToList();

        var roles = await _userManager.GetRolesAsync(user);
        foreach (var roleName in roles)
        {
            var role = IdentityRoleEnumeration.GetAll().FirstOrDefault(x => x.Name == roleName);
            claims.AddRange(await _roleManager.GetClaimsAsync(role));
        }

        context.IssuedClaims.AddRange(claims);
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var id = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(id);
        context.IsActive = user is not null;
    }
}
