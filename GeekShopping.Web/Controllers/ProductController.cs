using GeekShopping.Web.Interfaces.Services;
using GeekShopping.Web.Models;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers;

[Authorize]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAsync();
        return View(products);
    }

    [HttpGet]
    public async ValueTask<IActionResult> Form(int? id)
    {
        if (!id.HasValue) return View();
        var product = await _productService.GetByIdAsync(id.Value);
        if (product is null) return NotFound();
        return View(product);
    }

    [HttpPost, HttpPut]
    public async Task<ActionResult> Form(ProductModel productModel)
    {
        if (!ModelState.IsValid) return View(productModel);

        var response = !productModel.Id.HasValue
            ? await _productService.CreateAsync(productModel)
            : await _productService.UpdateAsync(productModel);

        if (response.HasErrors) return View(productModel);
        return RedirectToAction("Index");
    }

    [HttpGet, Authorize(Roles = Role.ADMIN)]
    public async Task<ActionResult> Delete(int id)
    {
        await _productService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
