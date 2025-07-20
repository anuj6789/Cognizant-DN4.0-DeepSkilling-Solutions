//namespace Jwtmicro.Controllers
//{
//    public class ProtectedController
//    {
//    }
//}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProtectedController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecret()
    {
        return Ok("You are Authorized");
    }
}
