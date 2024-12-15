using GeekShopping.Identity.Data.DataSeeder;
using GeekShopping.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SeedData();
        base.OnModelCreating(builder);
    }
}
