using GeekShopping.CouponApi.Models.Common;

namespace GeekShopping.CouponApi.Models;

public class CartDetail : EntityBase
{
    public int CartHeaderId { get; private set; }
    public int ProductId { get; private set; }
    public int Count { get; private set; }

    public virtual CartHeader CartHeader { get; private set; }
    public virtual Coupon Product { get; private set; }

    public void SetProduct(Coupon product)
        => Product = product;

    public void SetCartHeaderId(int cartHeaderId)
        => CartHeaderId = cartHeaderId;

    public void SetCount(int count)
        => Count = count;
}
