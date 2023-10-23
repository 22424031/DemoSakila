using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoSakila.API.Middleware
{
    public class ApiKeyMiddleWare
    {
        private readonly RequestDelegate _next;
        public ApiKeyMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //if (!context.Request.Headers.TryGetValue())
            //{
            //  //  context.Result = new UnauthorizedObjectResult



            //}
        }
    }
}
