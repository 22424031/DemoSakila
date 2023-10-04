
using DemoSakila.API.LogUtility;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sakila.Application;
using Sakila.Persistent;
using Serilog;
using Serilog.Events;
using Serilog.Formatting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigurePersistenceRegister(builder.Configuration);
builder.Services.ConfigurateApplicationService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConnections();
builder.Services.AddOpenApiDocument();

string mySqlConnectionString = builder.Configuration.GetConnectionString("sakila");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    // Filter out ASP.NET Core infrastructre logs that are Information and below
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("my-logs/log.txt",rollingInterval: RollingInterval.Minute, rollOnFileSizeLimit: true)
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.MySQL(mySqlConnectionString, "Logs")
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
builder.Host.UseSerilog();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
   
}
app.UseSerilogRequestLogging(opts
        => opts.EnrichDiagnosticContext = LogHelper.EnrichFromRequest);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
