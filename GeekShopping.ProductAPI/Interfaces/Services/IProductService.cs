using GeekShopping.ProductAPI.Models.Common;
using GeekShopping.ProductAPI.ViewModels.Product;

namespace GeekShopping.ProductAPI.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAllAsync();
    Task<ProductResponse> GetByIdAsync(int id);
    Task<Result> CreateAsync(ProductRequest productViewModel);
    Task<Result> UpdateAsync(int id, ProductRequest productViewModel);
    Task<Result> DeleteAsync(int id);
}