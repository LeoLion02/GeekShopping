using Microsoft.AspNetCore.Mvc.Versioning;

namespace GeekShopping.CouponApi.Extensions;

public static class ApiVersioningExtensions
{
    public static void AddVersioning(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddApiVersioning(p =>
        {
            p.DefaultApiVersion = new(1, 0);
            p.ReportApiVersions = true;
            p.AssumeDefaultVersionWhenUnspecified = true;
            p.ApiVersionReader = new HeaderApiVersionReader("api-version");
        });

        serviceCollection.AddVersionedApiExplorer(p =>
        {
            p.GroupNameFormat = "'v'VVV";
            p.SubstituteApiVersionInUrl = true;
        });
    }
}
