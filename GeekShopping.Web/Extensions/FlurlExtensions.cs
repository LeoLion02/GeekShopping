using Flurl.Http;
using GeekShopping.Web.Models;
using GeekShopping.Web.Models.ApiResponses;
using System.Net;

namespace GeekShopping.Web.Extensions;

public static class FlurlExtensions
{
    public static async Task<ApiResponse<T>> GetResponseAsync<T>(this Task<IFlurlResponse> task)
        where T : class
    {
        var response = await task.ConfigureAwait(false);
        if (response is null) return default;

        if (response.StatusCode is (int)HttpStatusCode.BadRequest)
        {
            var result = await response.GetJsonAsync<ErrorModel>().ConfigureAwait(false);
            return new() { Errors = result.Errors };
        }

        return new() { Data = await response.GetJsonAsync<T>().ConfigureAwait(false) };
    }
}
