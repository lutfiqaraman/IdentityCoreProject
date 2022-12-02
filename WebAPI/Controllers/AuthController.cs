using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Authenticate([FromBody]Credential credential)
        {
            if (credential is not null)
            {
                if (credential.UserName == "admin" && credential.Password == "password")
                {

                }
            }
            
        }
    }
}
