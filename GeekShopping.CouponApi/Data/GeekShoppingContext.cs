using GeekShopping.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponApi.Data;

public class GeekShoppingContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; }

    public GeekShoppingContext(DbContextOptions<GeekShoppingContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeekShoppingContext).Assembly);
    }
}
