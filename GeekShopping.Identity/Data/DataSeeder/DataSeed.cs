using GeekShopping.Identity.Data.DataSeeder.Seeds;
using GeekShopping.Identity.Enumerations;
using GeekShopping.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Identity.Data.DataSeeder;

public static class DataSeed
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>().HasData(ApplicationUserEnumeration.GetAll());
        modelBuilder.Entity<Models.IdentityRole>().HasData(IdentityRoleEnumeration.GetAll());
        modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRoleSeeder().GetData());
        modelBuilder.Entity<IdentityUserClaim<int>>().HasData(new IdentityUserClaimSeeder().GetData());
    }
}
