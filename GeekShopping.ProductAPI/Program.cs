using FluentValidation;
using GeekShopping.ProductAPI.Configurations;
using GeekShopping.ProductAPI.Data;
using GeekShopping.ProductAPI.Data.Repositories;
using GeekShopping.ProductAPI.Data.UnitOfWork;
using GeekShopping.ProductAPI.Interfaces.Repositories;
using GeekShopping.ProductAPI.Interfaces.Services;
using GeekShopping.ProductAPI.Services;
using GeekShopping.ProductAPI.Validations;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.WithExceptionDetails()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.ConfigureApiVersioning();

builder.Services.AddDbContext<GeekShoppingContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(ProductRequestValidation));
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.SaveToken = true;
    options.Authority = "https://localhost:5001";
    options.TokenValidationParameters = new()
    {
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy => policy.RequireClaim("scope", "geek_shopping"));
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
