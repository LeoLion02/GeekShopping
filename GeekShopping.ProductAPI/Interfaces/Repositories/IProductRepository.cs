using GeekShopping.ProductAPI.Models;

namespace GeekShopping.ProductAPI.Interfaces.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}
