using GeekShopping.CartAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CartAPI.Data.Map;

public class CartHeaderMap : IEntityTypeConfiguration<CartHeader>
{
    public void Configure(EntityTypeBuilder<CartHeader> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.CouponCode)
            .IsRequired(false);
    }
}
