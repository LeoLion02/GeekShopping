namespace GeekShopping.ProductAPI.Configurations;

public static class ApiVersioningConfiguration
{
    public static void ConfigureApiVersioning(this IServiceCollection serviceCollection) 
    {
        serviceCollection.AddApiVersioning(p =>
        {
            p.DefaultApiVersion = new(1, 0);
            p.ReportApiVersions = true;
            p.AssumeDefaultVersionWhenUnspecified = true;
        });

        serviceCollection.AddVersionedApiExplorer(p =>
        {
            p.GroupNameFormat = "'v'VVV";
            p.SubstituteApiVersionInUrl = true;
        });
    }
}
