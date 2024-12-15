using Flurl;
using Flurl.Http;
using GeekShopping.Web.Interfaces.Services;
using GeekShopping.Web.Models;
using GeekShopping.Web.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net;

namespace GeekShopping.Web.Services;

public class CouponService : ICouponService
{
    private readonly HttpContext _httpContext;
    private readonly string _apiUrl;

    public CouponService(
        IOptions<ServiceUrlsSettings> serviceUrls,
        IHttpContextAccessor httpContextAccessor)
    {
        _apiUrl = serviceUrls.Value.CouponApi;
        _httpContext = httpContextAccessor.HttpContext!;
    }


    public async Task<CouponModel> GetCouponAsync(string code)
        => await _apiUrl.AppendPathSegment(code)
            .AllowHttpStatus(HttpStatusCode.NotFound)
            .WithOAuthBearerToken(await _httpContext.GetTokenAsync("access_token"))
            .GetJsonAsync<CouponModel>();
}
