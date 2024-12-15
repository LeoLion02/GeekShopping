using GeekShopping.CartAPI.Interfaces.Repositories;
using GeekShopping.CartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Data.Repositories;

public class CartRepository : ICartRepository
{
    private readonly GeekShoppingContext _context;

    public CartRepository(GeekShoppingContext context)
    {
        _context = context;
    }

    public async Task<CartHeader?> GetCartHeaderByUserIdAsync(string userId)
        => await _context.CartHeaders.AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId);

    public async Task<CartDetail?> GetCartDetailByIdAsync(int cartDetailId)
       => await _context.CartDetails.FindAsync(cartDetailId);

    public async Task<int> GetCartDetailCountByCartHeaderId(int cartHeaderId)
       => await _context.CartDetails.CountAsync(x => x.CartHeaderId == cartHeaderId);

    public async Task<CartDetail?> GetCartDetailByProductIdAndCartHeaderIdAsync(int productId, int cartHeaderId)
        => await _context.CartDetails.AsNoTracking()
            .FirstOrDefaultAsync(x => x.CartHeaderId == cartHeaderId && x.ProductId == productId);

    public async Task<CartDetail?> GetCardDetailByProductIdAsync(int productId)
        => await _context.CartDetails.FirstOrDefaultAsync(x => x.ProductId == productId);

    public async Task AddCartDetailAsync(CartDetail cartDetail)
        => await _context.CartDetails.AddAsync(cartDetail);

    public async Task UpdateCartDetailAsync(CartDetail cartDetail)
        => await Task.FromResult(_context.CartDetails.Update(cartDetail));

    public async Task UpdateCartHeaderAsync(CartHeader cartHeader)
        => await Task.FromResult(_context.CartHeaders.Update(cartHeader));

    public async Task AddCartHeaderAsync(CartHeader cartHeader)
        => await _context.CartHeaders.AddAsync(cartHeader);

    public async Task<IEnumerable<CartDetail>> GetCartDetailsWithProductByCartHeaderIdAsync(int cartHeaderId)
        => await _context.CartDetails
           .AsNoTrackingWithIdentityResolution()
           .Include(x => x.Product)
           .Where(x => x.CartHeaderId == cartHeaderId)
           .ToListAsync();

    public async Task DeleteCartDetailAsync(CartDetail cartDetail)
        => await Task.FromResult(_context.CartDetails.Remove(cartDetail));

    public async Task DeleteCartDetailsWithCartHeaderIdAsync(int cartHeaderId)
        => await _context.CartDetails.Where(x => x.CartHeaderId == cartHeaderId).ExecuteDeleteAsync();

    public async Task DeleteCartHeaderAsync(CartHeader cartHeader)
        => await Task.FromResult(_context.CartHeaders.Remove(cartHeader));

    public async Task DeleteCartHeaderAsync(int cartHeaderId)
        => await _context.CartHeaders.Where(x => x.Id == cartHeaderId).ExecuteDeleteAsync();
}
