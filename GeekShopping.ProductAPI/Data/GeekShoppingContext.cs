using GeekShopping.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Data;

public class GeekShoppingContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    public GeekShoppingContext(DbContextOptions<GeekShoppingContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeekShoppingContext).Assembly);
    }
}
