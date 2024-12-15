using GeekShopping.CouponApi.Models.Common;

namespace GeekShopping.CouponApi.Models;

public class CartHeader : EntityBase
{
    public string UserId { get; private set; }
    public string CouponCode { get; private set; }
}
