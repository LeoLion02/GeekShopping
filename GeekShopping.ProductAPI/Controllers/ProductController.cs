using GeekShopping.ProductAPI.Controllers.Common;
using GeekShopping.ProductAPI.Interfaces.Services;
using GeekShopping.ProductAPI.Utils;
using GeekShopping.ProductAPI.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers;

[Authorize]
public class ProductController : BaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet, AllowAnonymous]
    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
        => await _productService.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ProductResponse> GetByIdAsync([FromRoute] int id)
        => await _productService.GetByIdAsync(id);

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ProductRequest productViewModel)
        => GetResponseFromResult(await _productService.CreateAsync(productViewModel));

    [HttpPut("{id:int}")]
    public async Task UpdateAsync([FromRoute] int id, [FromBody] ProductRequest productViewModel)
        => GetResponseFromResult(await _productService.UpdateAsync(id, productViewModel));

    [HttpDelete("{id:int}"), Authorize(Roles = Role.ADMIN)]
    public async Task DeleteAsync([FromRoute] int id)
       => GetResponseFromResult(await _productService.DeleteAsync(id));
}
