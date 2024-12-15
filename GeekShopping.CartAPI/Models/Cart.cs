namespace GeekShopping.CartAPI.Models;

public class Cart
{
    private Cart() { }
    public Cart(CartHeader cartHeader, IEnumerable<CartDetail> cartDetails)
    {
        CartHeader = cartHeader;
        CartDetails = cartDetails;
    }

    public CartHeader CartHeader { get; private set; }
    public IEnumerable<CartDetail> CartDetails { get; private set; }
}
