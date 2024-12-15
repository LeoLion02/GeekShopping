using Duende.IdentityServer.Services;
using GeekShopping.Identity.Data;
using GeekShopping.Identity.Models;
using GeekShopping.Identity.Services;
using GeekShopping.Identity.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace GeekShopping.Identity;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var identityBuilder = builder.Services.AddIdentity<ApplicationUser, Models.IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
            options.Lockout.MaxFailedAccessAttempts = 3;
        });

        identityBuilder
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Development", builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        builder.Services.AddIdentityServer(builder.Configuration);

        builder.Services.AddAuthentication();

        builder.Services.AddOptions<IdentityServerSettings>();

        builder.Services.AddScoped<IProfileService, ProfileService>();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseCors("Development");

        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();

        app.MapRazorPages()
            .RequireAuthorization();

        //using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        //var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //context.Database.Migrate();

        return app;
    }
}