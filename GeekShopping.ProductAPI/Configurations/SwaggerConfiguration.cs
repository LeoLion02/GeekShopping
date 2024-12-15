using Microsoft.OpenApi.Models;

namespace GeekShopping.ProductAPI.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.ProductApi", Version = "v1" });
            options.EnableAnnotations();

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Enter 'Bearer' [space] and your token.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }});
        });
    }
}
