namespace GeekShopping.Web.Models;

public class ErrorModel
{
    public IEnumerable<string> Errors { get; set; }
    public string Message { get; set; }
}
