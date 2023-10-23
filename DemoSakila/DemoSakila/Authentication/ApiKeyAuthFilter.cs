using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sakila.Application.Dtos.Common;

namespace DemoSakila.API.Authentication
{
    public class ApiKeyAuthFilter : Attribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var baseResponse = new BaseResponse<string>();
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var actractedKey))
            {
                baseResponse.Status = 400;
                baseResponse.ErrorMessage = "Api Is Missing";
                context.Result = new UnauthorizedObjectResult(baseResponse);
                return;
            }
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            if (!actractedKey.Equals(configuration["ApiKey"]))
            {
                baseResponse.Status = 403;
                baseResponse.ErrorMessage = "Api Is Invalid";
                context.Result = new UnauthorizedObjectResult(baseResponse);
                return;
            }
        }
    }
}
