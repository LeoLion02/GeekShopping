using GeekShopping.CartAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CartAPI.Data.Map;

public class CartDetailMap : IEntityTypeConfiguration<CartDetail>
{
    public void Configure(EntityTypeBuilder<CartDetail> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithMany()
            .IsRequired();

        builder.HasOne(x => x.CartHeader)
            .WithMany()
            .IsRequired();
    }
}
