using GeekShopping.CouponApi.ViewModels;

namespace GeekShopping.CouponApi.Interfaces.Services;
public interface ICouponService
{
    Task<CouponViewModel> GetByCodeAsync(string code);
}   