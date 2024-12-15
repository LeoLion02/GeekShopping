using GeekShopping.CartAPI.Messages;
using GeekShopping.CartAPI.Models.Common;
using GeekShopping.CartAPI.ViewModels;

namespace GeekShopping.CartAPI.Interfaces.Services;

public interface ICartService
{
    Task<bool> UpdateCouponAsync(string userId, string couponCode);
    Task<Result<CartViewModel>> GetByUserIdAsync(string userId);
    Task RemoveFromCartAsync(int cartDetailId);
    Task<CartViewModel> SaveOrUpdateAsync(CartViewModel request);
    Task CheckoutAsync(CheckoutHeaderViewModel request);
}