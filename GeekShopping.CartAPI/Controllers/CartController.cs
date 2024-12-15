using GeekShopping.CartAPI.Controllers.Common;
using GeekShopping.CartAPI.Interfaces.Services;
using GeekShopping.CartAPI.Messages;
using GeekShopping.CartAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers;

public class CartController : BaseController
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserIdAsync([FromRoute] string userId)
        => GetResponseFromResult(await _cartService.GetByUserIdAsync(userId));

    [HttpPost]
    public async Task SaveOrUpdateAsync([FromBody] CartViewModel request)
        => await _cartService.SaveOrUpdateAsync(request);

    [HttpPatch("coupon")]
    public async Task UpdateCoupon([FromBody] CartHeaderViewModel request)
        => await _cartService.UpdateCouponAsync(request.UserId, request.CouponCode);

    [HttpPost("checkout")]
    public async Task CheckoutAsync(CheckoutHeaderViewModel request)
        => await _cartService.CheckoutAsync(request);

    [HttpDelete("{id}")]
    public async Task RemoveCartAsync([FromRoute] int id)
        => await _cartService.RemoveFromCartAsync(id);
}
