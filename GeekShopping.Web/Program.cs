using GeekShopping.Web.Interfaces.Services;
using GeekShopping.Web.Settings;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
services.AddHttpContextAccessor();

services.AddOptions<ServiceUrlsSettings>()
    .BindConfiguration("ServiceUrls")
    .ValidateDataAnnotations()
    .ValidateOnStart();

services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultAuthenticateScheme = "oidc";
})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
        options.GetClaimsFromUserInfoEndpoint = true;
        options.RequireHttpsMetadata = builder.Environment.IsProduction();
        options.ClientId = "geek_shopping";
        options.ClientSecret = builder.Configuration["IdentityServerSecret"];
        options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role", "role", "role");
        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("geek_shopping");
        options.SaveTokens = true;
    });

var teste = AppDomain.CurrentDomain
    .GetAssemblies()
    .SelectMany(x => x.GetTypes())
    .Where(x => x.IsClass && !x.IsAbstract)
    .Where(x => typeof(IService).IsAssignableFrom(x))
    .Where(x => !x.ContainsGenericParameters)
    .ToList();

teste.ForEach(x =>
{
    var @interface = x.GetInterface($"I{x.Name}");
    if (@interface is not null) builder.Services.AddScoped(@interface, x);
    else builder.Services.AddScoped(x);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
