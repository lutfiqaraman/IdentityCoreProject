using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Authenticate([FromBody] string data)
        {

        }
    }
}
