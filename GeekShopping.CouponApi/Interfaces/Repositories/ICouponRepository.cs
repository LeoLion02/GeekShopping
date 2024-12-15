using GeekShopping.CouponApi.Models;

namespace GeekShopping.CouponApi.Data.Repositories;

public interface ICouponRepository
{
    Task<Coupon?> GetCouponByCouponCode(string code);
}