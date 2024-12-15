namespace GeekShopping.Web.Models;

public class CartDetailModel
{
    public int Id { get; set; }
    public int CartHeaderId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }

    public virtual CartHeaderModel CartHeader { get; set; }
    public virtual ProductModel Product { get; set; }
}
