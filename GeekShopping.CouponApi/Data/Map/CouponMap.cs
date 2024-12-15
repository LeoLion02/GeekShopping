using GeekShopping.CouponApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CouponApi.Data.Map;

public class CouponMap : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(x => x.Id); 

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(c => c.DiscountAmount)
            .IsRequired();
    }
}
