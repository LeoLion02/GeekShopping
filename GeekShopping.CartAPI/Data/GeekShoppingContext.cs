using GeekShopping.CartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Data;

public class GeekShoppingContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<CartHeader> CartHeaders { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }


    public GeekShoppingContext(DbContextOptions<GeekShoppingContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeekShoppingContext).Assembly);
    }
}
