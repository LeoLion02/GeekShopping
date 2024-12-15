using GeekShopping.CartAPI.Interfaces.Repositories;
using GeekShopping.CartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly GeekShoppingContext _context;

    public ProductRepository(GeekShoppingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _context.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task CreateAsync(Product product)
        => await _context.Products.AddAsync(product);

    public async Task UpdateAsync(Product product)
        => await Task.FromResult(_context.Products.Update(product));

    public async Task DeleteAsync(Product product)
        => await Task.FromResult(_context.Products.Remove(product));
}
