

using DemoSakila.API.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sakila.Application;
using Sakila.Persistent;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System.Text;

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
        .WriteTo.MySQL(builder.Configuration.GetConnectionString("sakila_log"), "Logs_info",
            LogEventLevel.Information)
         .WriteTo.MySQL(builder.Configuration.GetConnectionString("sakila_log"), "Logs_error",
            LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .WriteTo.Console());

    builder.Services.ConfigurePersistenceRegister(builder.Configuration);
    builder.Services.ConfigurateApplicationService();
    //builder.Services.AddSingleton<IConfiguration>();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIApplication", Version = "v1" });
    });
    builder.Services.AddConnections();
    builder.Services.AddOpenApiDocument();
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(o =>
    {
        var jwt = builder.Configuration.GetSection("jwtBearer");
        o.TokenValidationParameters = new TokenValidationParameters
        {

            ValidIssuer = builder.Configuration["jwtBearer:Issuer"],
            ValidAudience = builder.Configuration["jwtBearer:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtBearer:SigningKey"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
  
    builder.Services.AddAuthorization();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi();
       // app.UseSwagger();
        app.UseSwaggerUi3();

    }
  
    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    //app.UseMiddleware<RequestResponseLoggingMiddleware>();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
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