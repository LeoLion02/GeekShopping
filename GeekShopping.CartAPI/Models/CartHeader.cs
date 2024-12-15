using GeekShopping.CartAPI.Models.Common;

namespace GeekShopping.CartAPI.Models;

public class CartHeader : EntityBase
{
    public string UserId { get; private set; }
    public string CouponCode { get; private set; }

    public void SetCouponCode(string couponCode)
    {
        CouponCode = couponCode;
    }
}
