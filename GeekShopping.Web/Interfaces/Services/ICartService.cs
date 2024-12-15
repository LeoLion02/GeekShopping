using GeekShopping.Web.Models;
using GeekShopping.Web.Models.ApiResponses;

namespace GeekShopping.Web.Interfaces.Services;

public interface ICartService : IService
{
    Task<CartModel> GetByUserIdAsync(string userId);
    Task RemoveCartAsync(int id);
    Task<ApiResponse<CartModel>> SaveOrUpdateAsync(CartModel request);
    Task UpdateCouponAsync(CartHeaderModel request);
    Task<ApiResponse<CartHeaderModel>> CheckoutAsync(CartHeaderModel request);
}