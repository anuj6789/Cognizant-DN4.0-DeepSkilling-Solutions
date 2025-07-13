using Microsoft.AspNetCore.Mvc;

namespace SwaggerDemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet("greet")]
        public IActionResult GetGreeting()
        {
            return Ok("Hello from SwaggerDemoAPI!");
        }
    }
}
