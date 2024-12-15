using GeekShopping.ProductAPI.Models;

namespace GeekShopping.ProductAPI.Data.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}
