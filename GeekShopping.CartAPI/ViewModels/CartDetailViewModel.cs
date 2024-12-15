namespace GeekShopping.CartAPI.ViewModels;

public class CartDetailViewModel
{
    public int CartHeaderId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }

    public CartHeaderViewModel CartHeader { get; set; }
    public ProductViewModel Product { get; set; }
}
