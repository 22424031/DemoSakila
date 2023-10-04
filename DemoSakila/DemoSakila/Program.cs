
using DemoSakila.API.Middleware;
using Sakila.Application;
using Sakila.Persistent;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
    
    .CreateLogger();
try
{
    builder.Services.AddControllers();

    Log.Information("Demo serilog");
    builder.Host
        .UseSerilog((ctx, lc) => lc
        .WriteTo.Console(new JsonFormatter(), LogEventLevel.Error)
        .WriteTo.File(new JsonFormatter(), "C:\\Users\\nguye\\Desktop\\demo-serilog\\log.txt", LogEventLevel.Information,
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true)
        .WriteTo.File(new JsonFormatter(), "C:\\Users\\nguye\\Desktop\\demo-serilog\\log-error.txt", LogEventLevel.Error,
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true)
        .WriteTo.MySQL(
            "server=127.0.0.1;port=3306;database=sakila;user=root;password=123qwe@@AA", "Logs",
            LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .WriteTo.Console());

    builder.Services.ConfigurePersistenceRegister(builder.Configuration);
    builder.Services.ConfigurateApplicationService();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddConnections();
    builder.Services.AddOpenApiDocument();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi();
        app.UseSwaggerUi3();

    }

    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseMiddleware<RequestResponseLoggingMiddleware>();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}