using GeekShopping.CartAPI.Models;

namespace GeekShopping.CartAPI.Interfaces.Repositories;

public interface ICartRepository
{
    Task<CartHeader?> GetCartHeaderByUserIdAsync(string userId);
    Task<CartDetail?> GetCardDetailByProductIdAsync(int productId);
    Task AddCartHeaderAsync(CartHeader cartHeader);
    Task AddCartDetailAsync(CartDetail cartHeader);
    Task UpdateCartDetailAsync(CartDetail cartDetail);
    Task<CartDetail?> GetCartDetailByProductIdAndCartHeaderIdAsync(int productId, int cartHeaderId);
    Task<IEnumerable<CartDetail>> GetCartDetailsWithProductByCartHeaderIdAsync(int cartHeaderId);
    Task<CartDetail?> GetCartDetailByIdAsync(int cartDetailId);
    Task<int> GetCartDetailCountByCartHeaderId(int cartHeaderId);
    Task DeleteCartHeaderAsync(int cartHeaderId);
    Task DeleteCartDetailAsync(CartDetail cartDetail);
    Task DeleteCartDetailsWithCartHeaderIdAsync(int cartHeaderId);
    Task DeleteCartHeaderAsync(CartHeader cartHeader);
    Task UpdateCartHeaderAsync(CartHeader cartHeader);
}
