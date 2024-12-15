using GeekShopping.CartAPI.Models.Common;

namespace GeekShopping.CartAPI.Models;

public class CartDetail : EntityBase
{
    public int CartHeaderId { get; private set; }
    public int ProductId { get; private set; }
    public int Count { get; private set; }

    public virtual CartHeader CartHeader { get; private set; }
    public virtual Product Product { get; private set; }

    public void SetProduct(Product product)
        => Product = product;

    public void SetCartHeaderId(int cartHeaderId)
        => CartHeaderId = cartHeaderId;

    public void SetCount(int count)
        => Count = count;
}
