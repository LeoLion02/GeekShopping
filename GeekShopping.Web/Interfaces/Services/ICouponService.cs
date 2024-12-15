using GeekShopping.Web.Models;

namespace GeekShopping.Web.Interfaces.Services;

public interface ICouponService : IService
{
    Task<CouponModel> GetCouponAsync(string code);
}