using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GeekShopping.Web.Models.ApiResponses;

public class ApiResponse<T> where T : class
{
    public T Data { get; set; }
    public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();
    public bool HasErrors => Errors.Any();

    public void AddErrorsToModelState(ModelStateDictionary modelState)
    {
        foreach (var error in Errors)
            modelState.AddModelError(string.Empty, error);
    }
}
