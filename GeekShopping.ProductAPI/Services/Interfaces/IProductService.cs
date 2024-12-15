using GeekShopping.ProductAPI.ViewModels;

namespace GeekShopping.ProductAPI.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<ProductViewModel> GetByIdAsync(int id);
    Task CreateAsync(ProductViewModel productViewModel);
    Task UpdateAsync(int id, ProductViewModel productViewModel);
    Task DeleteAsync(int id);
}