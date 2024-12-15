using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using GeekShopping.Identity.Models;
using GeekShopping.Identity.Services;
using GeekShopping.Identity.Settings;

namespace GeekShopping.Identity;

public static class Config
{
    public static void AddIdentityServer(this IServiceCollection services, IConfiguration configuration)
    {
        var identitySettings = configuration.GetSection("IdentityServerSettings")
            .Get<IdentityServerSettings>();

        var builder = services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.EmitStaticAudienceClaim = true;
        })
           .AddInMemoryIdentityResources(GetIdentityResources())
           .AddInMemoryApiScopes(GetApiScopes())
           .AddInMemoryClients(GetClients(identitySettings))
           .AddAspNetIdentity<ApplicationUser>()
           .AddProfileService<ProfileService>();

        builder.AddDeveloperSigningCredential();
    }

    #region Private Methods

    private static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

    private static IEnumerable<ApiScope> GetApiScopes() =>
        new List<ApiScope>
        {
            new("geek_shopping", "GeekShopping Server"),
            new("read", "Read data."),
            new("write", "Write data."),
            new("delete", "Delete data.")
        };

    private static IEnumerable<Client> GetClients(IdentityServerSettings settings) =>
        new List<Client>
        {
            new() {
                ClientId = "client",
                ClientSecrets = { new Secret(settings.ClientSecret.ToString().Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = new[] { "read", "write", "delete" }
            },
            new() {
                ClientId = "geek_shopping",
                ClientSecrets = { new Secret(settings.GeekShoppingSecret.ToString().Sha256()) },
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                RedirectUris = { "https://localhost:7064/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:7064/signout-callback-oidc" },
                AllowedCorsOrigins = { "http://localhost:4200" },
                AllowedScopes = new[] {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                    "geek_shopping"
                }
            }
        };

    #endregion
}
