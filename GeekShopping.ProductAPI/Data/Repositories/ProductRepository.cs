using GeekShopping.ProductAPI.Interfaces.Repositories;
using GeekShopping.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly GeekShoppingContext _context;

    public ProductRepository(GeekShoppingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _context.Product.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _context.Product.FindAsync(id);

    public async Task CreateAsync(Product product)
        => await _context.Product.AddAsync(product);

    public async Task UpdateAsync(Product product)
        => await Task.FromResult(_context.Product.Update(product));

    public async Task DeleteAsync(Product product)
        => await Task.FromResult(_context.Product.Remove(product));
}