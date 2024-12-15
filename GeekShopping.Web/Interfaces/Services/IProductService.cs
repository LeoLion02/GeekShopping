using GeekShopping.Web.Models;
using GeekShopping.Web.Models.ApiResponses;

namespace GeekShopping.Web.Interfaces.Services;

public interface IProductService : IService
{
    Task<IEnumerable<ProductModel>> GetAsync();

    Task<ProductModel> GetByIdAsync(int id);

    Task<ApiResponse<ProductModel>> CreateAsync(ProductModel productViewModel);

    Task<ApiResponse<ProductModel>> UpdateAsync(ProductModel productViewModel);

    Task DeleteAsync(int id);
}