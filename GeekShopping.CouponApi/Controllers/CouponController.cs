using GeekShopping.CouponApi.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CouponApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CouponController : ControllerBase
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpGet, Route("{code}")]
    public async Task<IActionResult> GetByCodeAsync([FromRoute] string code)
    {
        var coupon = await _couponService.GetByCodeAsync(code);
        if (coupon is null) return NotFound();
        return Ok(coupon);
    }
}
