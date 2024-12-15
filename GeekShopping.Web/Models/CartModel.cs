namespace GeekShopping.Web.Models;

public class CartModel
{
    public CartHeaderModel CartHeader { get; set; }
    public IEnumerable<CartDetailModel> CartDetails { get; set; }
}
