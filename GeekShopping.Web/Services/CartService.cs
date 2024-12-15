using Flurl;
using Flurl.Http;
using GeekShopping.Web.Extensions;
using GeekShopping.Web.Interfaces.Services;
using GeekShopping.Web.Models;
using GeekShopping.Web.Models.ApiResponses;
using GeekShopping.Web.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace GeekShopping.Web.Services;

public class CartService : ICartService
{
    private readonly HttpContext _httpContext;
    private readonly string _apiUrl;

    public CartService(
        IOptions<ServiceUrlsSettings> serviceUrls,
        IHttpContextAccessor httpContextAccessor)
    {
        _apiUrl = serviceUrls.Value.CartAPI;
        _httpContext = httpContextAccessor.HttpContext!;
    }

    public async Task<CartModel> GetByUserIdAsync(string userId)
        => await _apiUrl.AppendPathSegment(userId)
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .GetJsonAsync<CartModel>();

    public async Task<ApiResponse<CartModel>> SaveOrUpdateAsync(CartModel request)
        => await _apiUrl.AllowAnyHttpStatus()
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .PostJsonAsync(request)
            .GetResponseAsync<CartModel>();

    public async Task UpdateCouponAsync(CartHeaderModel request)
        => await _apiUrl.AppendPathSegment("coupon")
            .AllowAnyHttpStatus()
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .PatchJsonAsync(request);

    public async Task RemoveCartAsync(int id)
        => await _apiUrl.AppendPathSegment(id)
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .DeleteAsync();

    public async Task<ApiResponse<CartHeaderModel>> CheckoutAsync(CartHeaderModel request)
        => await _apiUrl.AppendPathSegment("checkout")
            .AllowAnyHttpStatus()
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .PostJsonAsync(request)
            .GetResponseAsync<CartHeaderModel>();
}