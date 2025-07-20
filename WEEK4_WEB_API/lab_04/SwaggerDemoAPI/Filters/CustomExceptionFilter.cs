using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SwaggerDemoAPI.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        File.WriteAllText("log.txt", context.Exception.Message);
        context.Result = new ObjectResult("Internal server error")
        {
            StatusCode = 500
        };
    }
}
