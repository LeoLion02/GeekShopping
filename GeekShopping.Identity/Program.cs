using GeekShopping.Identity;
using Serilog;
using Serilog.Exceptions;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .ReadFrom.Configuration(ctx.Configuration));

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.Run();