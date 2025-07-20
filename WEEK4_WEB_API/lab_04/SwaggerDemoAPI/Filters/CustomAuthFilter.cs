using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SwaggerDemoAPI.Filters;

public class CustomAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var hasAuthHeader = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
        if (!hasAuthHeader || !token.ToString().Contains("Bearer"))
        {
            context.Result = new BadRequestObjectResult("Invalid request - Missing or malformed Authorization header");
        }
    }
}
