using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Settings;

public class ServiceUrlsSettings
{
    [Required]
    public string ProductAPI { get; set; }

    [Required]
    public string CartAPI { get; set; }
    
    [Required]
    public string IdentityServer { get; set; }

    public string CouponApi { get; internal set; }
}
