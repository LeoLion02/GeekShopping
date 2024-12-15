using GeekShopping.Web.Interfaces.Services;
using GeekShopping.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly IProductService _productService;
    private readonly ICouponService _couponService;

    public CartController(
        IProductService productService,
        ICartService cartService,
        ICouponService couponService)
    {
        _productService = productService;
        _cartService = cartService;
        _couponService = couponService;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        return View(await FindUserCartAsync());
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UpdateCouponAsync(CartModel cartModel)
    {
        await _cartService.UpdateCouponAsync(cartModel.CartHeader);
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        await _cartService.RemoveCartAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Checkout()
    {
        return View(await FindUserCartAsync());
    }

    [HttpGet]
    public async Task<IActionResult> Confirmation()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Checkout(CartModel model)
    {
        var response = await _cartService.CheckoutAsync(model.CartHeader);
        if (response.HasErrors) return View(model);
        return RedirectToAction(nameof(Confirmation));
    }

    private async Task<CartModel?> FindUserCartAsync()
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var response = await _cartService.GetByUserIdAsync(userId);

        if (response?.CartHeader is not null)
        {
            var couponCode = response.CartHeader.CouponCode;
            if (!string.IsNullOrEmpty(couponCode))
            {
                var coupon = await _couponService.GetCouponAsync(couponCode);
                if (coupon?.Code is not null)
                {
                    response.CartHeader.DiscountAmount = coupon.DiscountAmount;
                }
            }

            foreach (var detail in response.CartDetails)
            {
                response.CartHeader.PurchaseAmount += detail.Product.Price * detail.Count;
            }

            response.CartHeader.PurchaseAmount -= response.CartHeader.DiscountAmount.GetValueOrDefault();
        }

        return response;
    }
}
