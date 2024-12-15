using GeekShopping.ProductAPI.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GeekShopping.ProductAPI.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult GetResponseFromResult(Result result)
    {
        if (result.IsFailure) return StatusCode((int)result.StatusCode!, result.ErrorMessage);
        return StatusCode((int)HttpStatusCode.OK, result.ErrorMessage);
    }
}
