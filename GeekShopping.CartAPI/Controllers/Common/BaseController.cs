using GeekShopping.CartAPI.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GeekShopping.CartAPI.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public abstract class BaseController : ControllerBase
{
    public IActionResult GetResponseFromResult<TValue>(Result<TValue> result) where TValue : class
    {
        if (result.IsFailure) return StatusCode((int)result.StatusCode!, result.ErrorMessage);
        return StatusCode((int)HttpStatusCode.OK, result.Value);
    }
}
