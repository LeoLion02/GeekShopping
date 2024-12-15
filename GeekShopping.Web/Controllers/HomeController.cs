using GeekShopping.Web.Interfaces.Services;
using GeekShopping.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeekShopping.Web.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public HomeController(
        ILogger<HomeController> logger,
        IProductService productService,
        ICartService cartService)
    {
        _logger = logger;
        _productService = productService;
        _cartService = cartService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAsync();
        return View(products);
    }

    [Authorize]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return View(product);
    }

    [HttpPost]
    [ActionName("Details")]
    [Authorize]
    public async Task<IActionResult> DetailsPost(ProductModel product)
    {
        var token = await HttpContext.GetTokenAsync("access_token");

        var cartDetail = new CartDetailModel
        {
            Count = product.Count,
            ProductId = product.Id.GetValueOrDefault(),
            Product = await _productService.GetByIdAsync(product.Id.GetValueOrDefault())
        };

        var cart = new CartModel
        {
            CartHeader = new() { UserId = User.Claims.Where(x => x.Type == "sub").FirstOrDefault()?.Value },
            CartDetails = new[] { cartDetail }
        };

        var response = await _cartService.SaveOrUpdateAsync(cart);
        if (response.HasErrors) response.AddErrorsToModelState(ModelState);

        return View(product);
    }

    public IActionResult Login()
    {
        return Challenge(new AuthenticationProperties() { RedirectUri = "Home/Index" }, "oidc");
    }

    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorModel { Message = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
