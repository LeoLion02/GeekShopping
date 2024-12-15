using GeekShopping.CartAPI.Data;
using GeekShopping.CartAPI.Data.Repositories;
using GeekShopping.CartAPI.Data.UnitOfWork;
using GeekShopping.CartAPI.Extensions;
using GeekShopping.CartAPI.Interfaces.Repositories;
using GeekShopping.CartAPI.Interfaces.Services;
using GeekShopping.CartAPI.RabbitMqSender;
using GeekShopping.CartAPI.Services;
using Serilog;
using Serilog.Exceptions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

Log.Logger = new LoggerConfiguration()
    .Enrich.WithExceptionDetails()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddVersioning();

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IRabbitMqMessageSender, RabbitMqMessageSender>();

builder.AddSqlServerDbContext<GeekShoppingContext>("sqldata");

builder.Services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));

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
    options.AddPolicy("ApiScope", policy => policy.RequireClaim("scope", "geek_shopping")));

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();