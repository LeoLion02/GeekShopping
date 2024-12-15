using GeekShopping.CartAPI.ViewModels;

namespace GeekShopping.CartAPI.Messages;

public class CheckoutHeaderViewModel
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string CouponCode { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal? DiscountAmount { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Time { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpireMonthYear { get; set; }
    public int CartTotalItems { get; set; }
    public IEnumerable<CartDetailViewModel> CartDetails { get; set; }
}
