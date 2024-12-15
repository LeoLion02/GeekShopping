using GeekShopping.CouponApi.Models.Common;

namespace GeekShopping.CouponApi.Models;

public class Coupon : EntityBase
{
    public string Code { get; private set; }
    public decimal DiscountAmount { get; private set; }
}
