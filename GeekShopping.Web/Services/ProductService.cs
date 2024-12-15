using Flurl;
using Flurl.Http;
using GeekShopping.Web.Extensions;
using GeekShopping.Web.Interfaces.Services;
using GeekShopping.Web.Models;
using GeekShopping.Web.Models.ApiResponses;
using GeekShopping.Web.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpContext _httpContext;
    private readonly string _apiUrl;

    public ProductService(
        IOptions<ServiceUrlsSettings> serviceUrls,
        IHttpContextAccessor httpContextAccessor)
    {
        _apiUrl = serviceUrls.Value.ProductAPI;
        _httpContext = httpContextAccessor.HttpContext!;
    }

    public async Task<IEnumerable<ProductModel>> GetAsync()
        => await _apiUrl.GetJsonAsync<IEnumerable<ProductModel>>();

    public async Task<ProductModel> GetByIdAsync(int id)
        => await _apiUrl.AppendPathSegment(id)
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .GetJsonAsync<ProductModel>();

    public async Task<ApiResponse<ProductModel>> CreateAsync(ProductModel productViewModel)
        => await _apiUrl.AllowHttpStatus(HttpStatusCode.BadRequest)
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .PostJsonAsync(productViewModel)
            .GetResponseAsync<ProductModel>();

    public async Task<ApiResponse<ProductModel>> UpdateAsync(ProductModel productViewModel)
        => await _apiUrl.AllowHttpStatus(HttpStatusCode.BadRequest)
            .AppendPathSegment(productViewModel.Id.Value)
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .PutJsonAsync(productViewModel)
            .GetResponseAsync<ProductModel>();

    public async Task DeleteAsync(int id)
        => await _apiUrl.AllowHttpStatus(HttpStatusCode.BadRequest)
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .AppendPathSegment(id)
            .DeleteAsync();
}
